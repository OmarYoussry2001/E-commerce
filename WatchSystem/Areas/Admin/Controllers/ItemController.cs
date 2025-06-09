using BL.Constants;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resources;
using UI.Controllers.Base;

namespace WatchSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Roles.Admin)] 
    public class ItemController : BaseController
    {
        private readonly  IItemService _itemService;
        private readonly ITypeService _typeService;
        private readonly IImageService _imageService;
        private readonly IDescriptionService _descriptionService;


        public ItemController(IItemService itemService, ITypeService typeService  , IDescriptionService descriptionService,  IImageService imageService, Serilog.ILogger logger) : base(logger)
        {
            _itemService = itemService;
            _imageService = imageService;
            _typeService = typeService ;
            _descriptionService = descriptionService;
        }

        public IActionResult List()
        {
            try
            {
                var entities = _itemService.GetItemsWithTypeName();
                return View(entities);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPost]
        public IActionResult GetItemsDataTable()
        {
            try
            {
                var start = int.Parse(Request.Form["start"]);   
                var pageSize = int.Parse(Request.Form["length"]);

                var pageNumber = (start / pageSize) + 1;
                var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"],"][name]")];
                var sortColumnDirection = Request.Form["order[0][dir]"];
                var orderBy = $"{sortColumn} {sortColumnDirection}";

                var searchTerm = Request.Form["search[value]"];

                var entities = _itemService.GetAllItemsByPagination(pageNumber , pageSize , searchTerm , orderBy);
                var recordsTotal = entities.TotalRecords;
                var jsonData = new {recordsFiltered = recordsTotal, recordsTotal, data = entities.Items };
                return Ok(jsonData);
               
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

                var entity = new ItemDto();

                if (id != default)
                {
                    entity = _itemService.FindById(id);
                    entity.Description = _descriptionService.Find(x => x.ItemId == entity.Id);
                    entity.Images = _imageService.Get(x => x.ItemId == entity.Id).ToList();
                }
                entity.Types = _typeService.GetAll();

                return View(entity);
            }

            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Save(ItemDto entity)
        {

            if (entity.ImagePathBackGround == null && entity.ImageBackGround == null)
            {
                ModelState.AddModelError(nameof(entity.ImageBackGround), ValidationResources.RequiredField);
            }

            if (!ModelState.IsValid)
                return View("Edit", entity);

            try
            {
                var result = await _itemService.Save(entity, GuidUserId);

                if (!result)
                {
                    TempData["ErrorMessage"] = NotifiAndAlertsResources.SaveFailed;
                    return View("Edit", entity);
                }

                TempData["SuccessMessage"] = NotifiAndAlertsResources.SavedSuccessfully;
                return RedirectToAction("List", "Item", new { area = "Admin" });


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
                _itemService.Delete(id);
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
