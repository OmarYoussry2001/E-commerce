using BL.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Base;
using WatchSystem.Models;
using WatchSystem.ViewModels;

namespace WatchSystem.Controllers
{
    public class ItemController : BaseController
    {

        private IItemService _itemService;
        private IImageService _imageService;

        public ItemController(IItemService itemService, IImageService imageService , Serilog.ILogger logger) : base(logger)
        {
            _itemService = itemService;
            _imageService = imageService;       
        }
        public IActionResult ItemDetails(Guid id)
        {
            try
            {
                VmItemDetails vmItemDetails = new VmItemDetails();
                vmItemDetails.Item = _itemService.Find(id);
                vmItemDetails.Images = _imageService.Get(x => x.ItemId == id);
                vmItemDetails.RelatedItems = _itemService.GetRelatedItems(id);

                return View(vmItemDetails);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
