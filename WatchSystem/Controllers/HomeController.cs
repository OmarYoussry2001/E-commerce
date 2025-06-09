using BL.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Resources;
using Resources.Enumerations;
using System.Diagnostics;
using UI.Controllers.Base;
using WatchSystem.Models;
using WatchSystem.ViewModels;

namespace WatchSystem.Controllers
{
    public class HomeController : BaseController
    {


        private IItemService _itemService;
        private ITypeService _typeService;
        private ISliderService _sliderService;
        private ISettingsService _settingsService;

        public HomeController(IItemService itemService, ITypeService typeService, ISliderService sliderService, ISettingsService settingsService, Serilog.ILogger logger) : base(logger)
        {
            _itemService = itemService;
            _typeService = typeService;
            _sliderService = sliderService;
            _settingsService = settingsService;
        }


        public IActionResult Index()
        {
            try
            {
                VmHomePage vmHomePage = new VmHomePage();
                vmHomePage.SpecialOffers = _itemService.GetSpecialOffers();
                vmHomePage.NewItems = _itemService.GetNewItems();
                vmHomePage.BestSellers = _itemService.GetBestSellers();
                vmHomePage.FeaturedProducts = _itemService.GetFeaturedProducts();
                vmHomePage.AllItems = _itemService.GetAllItems();
                vmHomePage.ItemTypes = _typeService.GetAll().Take(4).ToList();
                vmHomePage.Sliders = _sliderService.GetAll().Take(4).ToList();

                return View(vmHomePage);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
   
        }
        public IActionResult AboutUs()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public IActionResult ContactUs()
        {
            var entity = _settingsService.GetSettings();
            return View(entity);
        }
        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Product()
        {
            try
            {
                VmHomePage vmHomePage = new VmHomePage();
                vmHomePage.AllItems = _itemService.GetAllItems();
                return View(vmHomePage);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            };
        }
     

    }
}
