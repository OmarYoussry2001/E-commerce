using Microsoft.AspNetCore.Mvc;
using Resources;
using System.Security.Claims;

namespace UI.Controllers.Base
{

    public class BaseController : Controller
    {
        private readonly Serilog.ILogger _logger;

        public BaseController(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        protected string? UserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        protected Guid GuidUserId =>
       Guid.TryParse(UserId, out var guid) ? guid : Guid.NewGuid();

        // Centralized error handling
        protected IActionResult HandleException(Exception ex)
        {
            _logger.Error(ex, "An error occurred while processing your request.", ex.Message);

            TempData["ErrorMessage"] = ValidationResources.UnexpectedError;
            return RedirectToAction("Error", "Home");
        }
    }
}
