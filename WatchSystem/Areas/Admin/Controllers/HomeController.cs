using BL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources;
using Resources.Enumerations;
using System.Diagnostics;
using UI.Controllers.Base;
using WatchSystem.Models;

namespace WatchSystem.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Admin)]
    public class HomeController : BaseController
    {
        public HomeController(Serilog.ILogger logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
     

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Localization()
        {
            ResourceManager.CurrentLanguage = ResourceManager.CurrentLanguage == Language.Arabic ? Language.English : Language.Arabic;

            return Ok();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
