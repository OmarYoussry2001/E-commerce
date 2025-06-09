using BL.Constants;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.Controllers.Base;

using WatchSystem.Models;
using WatchSystem.Services.Contracts;
using WatchSystem.Utlities;

namespace WatchSystem.Controllers
{
    public class OrderController : BaseController
    {

        private IItemService _itemService;
        private ICartService _cartService;
        private ISalesInvoiceService _salesInvoiceService;

        public OrderController(IItemService itemService,  ICartService cartService, ISalesInvoiceService salesInvoiceService, Serilog.ILogger logger) : base(logger)
        {
            _itemService = itemService;
            _cartService = cartService;
            _salesInvoiceService = salesInvoiceService;
        }
        public IActionResult Cart()
        {
            ShoppingCartIGeneral shoppingCartIGeneral;
            if (HttpContext.Request.Cookies["Cart"] != null)
                shoppingCartIGeneral = JsonConvert.DeserializeObject<ShoppingCartIGeneral>(HttpContext.Request.Cookies["Cart"]);
            else
                shoppingCartIGeneral = new ShoppingCartIGeneral();
            return View(shoppingCartIGeneral);

        }
        [HttpPost]
        public IActionResult UpdateCartQuantity([FromBody] UpdateCartQtyModel model)
        {
            if (HttpContext.Request.Cookies["Cart"] != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCartIGeneral>(HttpContext.Request.Cookies["Cart"]);

                var item = cart.ShoppingCartItems.FirstOrDefault(x => x.ShoppingCartItemID == model.ItemId);
                if (item != null)
                {
                    item.Qty = model.Qty;
                    item.Total = item.Qty * item.Price;
                    cart.Total = cart.ShoppingCartItems.Sum(i => i.Total);

                    HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));
                }
            }

            return Ok();
        }

        public class UpdateCartQtyModel
        {
            public Guid ItemId { get; set; }
            public int Qty { get; set; }
        }

        public IActionResult AddToCart(Guid id)
        {
            try
            {
                _cartService.AddToCart(id);
                return RedirectToAction("Cart");
            }
            catch (Exception ex)
            {
                // Log error (e.g., using ILogger)
                return RedirectToAction("Error", new { message = "Failed to add item to cart." });
            }
        }

        [Authorize]
        public async Task<IActionResult> OrderSuccess()
        {
            try

            {
                ShoppingCartIGeneral shoppingCartIGeneral;
                if (HttpContext.Request.Cookies["Cart"] != null)
                    shoppingCartIGeneral = JsonConvert.DeserializeObject<ShoppingCartIGeneral>(HttpContext.Request.Cookies["Cart"]);
                else
                    shoppingCartIGeneral = new ShoppingCartIGeneral();
                await SaveOrder(shoppingCartIGeneral);

                return View("OrderSuccess", shoppingCartIGeneral);
            }


            catch (Exception ex)
            {
                return HandleException(ex);
            }


        }

      private async Task SaveOrder(ShoppingCartIGeneral shoppingCartIGeneral)
        {

                SalesInvoiceDto tbSalesInvoice = new SalesInvoiceDto();
                tbSalesInvoice.SalesInvoiceItems = _cartService.MapCartItemsToInvoiceItems(shoppingCartIGeneral);
                tbSalesInvoice.InvoiceDate = DateTime.Now;
                tbSalesInvoice.ApplicationUserId = UserId;
                tbSalesInvoice.DeliveryDate = DateTime.Now.AddDays(2);
                tbSalesInvoice.InvoiceDate = DateTime.Now;
                await _salesInvoiceService.Save(tbSalesInvoice, GuidUserId);


        }
    }

}

