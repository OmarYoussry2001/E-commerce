using BL.Constants;
using BL.Contracts.Services;
using BL.DTO.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources;
using Shared.GeneralModels.SearchCriteriaModels;
using System.Threading.Tasks;
using UI.Controllers.Base;

namespace UI.Area.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Admin)]

    public class SliderController : BaseController
    {
        private ISliderService _sliderService;
        public SliderController(ISliderService sliderService, Serilog.ILogger logger) : base(logger)
        {
            _sliderService = sliderService;
        }

        public IActionResult List()
        {
            try
            {
                var entities = _sliderService.GetAll();
                return View(entities);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public IActionResult Edit(Guid id)
        {
            try
            {

                var entity = new SliderDto();

                if (id != default)
                {
                    entity = _sliderService.FindById(id);
                }

                return View(entity);
            }

            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Save(SliderDto entity)
        {

            if (entity.ImagePath == null && entity.Image == null)
            {
                ModelState.AddModelError(nameof(entity.Image), ValidationResources.RequiredField);
            }

            if (!ModelState.IsValid)
                return View("Edit", entity);

            try
            {
                var result =await _sliderService.Save(entity, GuidUserId);

                if (!result)
                {
                    TempData["ErrorMessage"] = NotifiAndAlertsResources.SaveFailed;
                    return View("Edit", entity);
                }

                TempData["SuccessMessage"] = NotifiAndAlertsResources.SavedSuccessfully;
                return RedirectToAction("List", "Slider", new { area = "Admin" });


            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }


        }
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                TempData["ErrorMessage"] = NotifiAndAlertsResources.DeleteFailed;
                return RedirectToAction("List");
            }

            try
            {
                _sliderService.Delete(id);
                TempData["SuccessMessage"] = NotifiAndAlertsResources.DeletedSuccessfully;
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

            return RedirectToAction("List");
        }
    }
}
