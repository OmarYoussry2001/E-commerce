// في مجلد Services (مثلاً: WatchSystem.Services)
using BL.Contracts.Services;
using BL.DTO.Entities;
using Newtonsoft.Json;
using WatchSystem.Models;
using WatchSystem.Services.Contracts;
using WatchSystem.Utlities;

public class CartService : ICartService
{
    private readonly IItemService _itemService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IItemService itemService, IHttpContextAccessor httpContextAccessor)
    {
        _itemService = itemService;
        _httpContextAccessor = httpContextAccessor;
    }

    public ShoppingCartIGeneral GetOrCreateCart()
    {
        var cartJson = _httpContextAccessor.HttpContext.Request.Cookies["Cart"];
        return cartJson != null
            ? JsonConvert.DeserializeObject<ShoppingCartIGeneral>(cartJson)
            : new ShoppingCartIGeneral();
    }

    public void AddToCart(Guid itemId)
    {
        var cart = GetOrCreateCart();
        var existingItem = cart.ShoppingCartItems.FirstOrDefault(x => x.ShoppingCartItemID == itemId);

        if (existingItem != null)
        {
            existingItem.Qty++;
            existingItem.Total = existingItem.Qty * existingItem.Price;
        }
        else
        {
            var item = _itemService.Find(itemId);
            if (item == null)
                throw new ArgumentException("Item not found.");

            var discountedPrice = Math.Round(Helper.CalculateDiscount(item.Price, item.DiscountPercent), 2);

            cart.ShoppingCartItems.Add(new ShoppingCartItem
            {
                ShoppingCartItemID = item.Id,
                Price = discountedPrice,
                ItemName = item.Title,
                ImagePath = item.ImagePathBackGround,
                Qty = 1,
                Total = discountedPrice
            });
        }

        cart.Total = cart.ShoppingCartItems.Sum(x => x.Total);
        SaveCart(cart);
    }

    public void SaveCart(ShoppingCartIGeneral cart)
    {
        var cartJson = JsonConvert.SerializeObject(cart);
        _httpContextAccessor.HttpContext.Response.Cookies.Append("Cart", cartJson);
    }
    public List<SalesInvoiceItemDto> MapCartItemsToInvoiceItems(ShoppingCartIGeneral shoppingCartIGeneral)
    {
        List<SalesInvoiceItemDto> salesInvoiceItem = new List<SalesInvoiceItemDto>();
        foreach (var item in shoppingCartIGeneral.ShoppingCartItems)
        {
            salesInvoiceItem.Add(new SalesInvoiceItemDto
            {
                Qty = item.Qty,
                Price = item.Price,
                ItemID = item.ShoppingCartItemID


            });
        }
        return salesInvoiceItem;
    }
}