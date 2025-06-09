using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Contracts.UnitOfWork;
using DAL.Models;
using DAL.Repositories;
using DAL.UnitOfWork;
using Domains.Entities;
using Domains.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using DAL.Contracts.Repositories.Custom;
using DAL.Contracts.Repositories.Generic;

namespace BL.Services
{
    public class ItemService : BaseService<TbItem, ItemDto>, IItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;
        private readonly IItemRepository _itemRepository;
        private readonly IRepository<VwItemWithTypeName> _repository;

        public ItemService(IUnitOfWork unitOfWork, IFileUploadService fileUploadService,
               IImageProcessingService imageProcessingService, IRepository<VwItem> baseRepository,
               IItemRepository itemRepository, IRepository<VwItemWithTypeName> repository, IBaseMapper mapper) : base(unitOfWork.TableRepository<TbItem>(), mapper)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
            _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _repository = repository;
            _mapper = mapper;
        }

        public async new Task<bool> Save(ItemDto dto, Guid userId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty", nameof(userId));

            try
            {
                await ProcessImages(dto);

                var entityItem = _mapper.MapModel<ItemDto, TbItem>(dto);
                var descriptionEntity = _mapper.MapModel<DescriptionDto, TbDescription>(dto.Description);
                var imagesEntities = _mapper.MapList<ImageDto, TbImage>(dto.Images);

                entityItem.Images = new List<TbImage>();

                await _unitOfWork.BeginTransactionAsync();

                // Save item
                if (!_unitOfWork.TableRepository<TbItem>().Save(entityItem, userId, out Guid itemId))
                    throw new Exception("Failed to save item");

                // Save description
                descriptionEntity.ItemId = itemId;
                if (!_unitOfWork.TableRepository<TbDescription>().Save(descriptionEntity, userId))
                    throw new Exception("Failed to save description");

                // Save images
                foreach (var img in imagesEntities)
                    img.ItemId = itemId;

                    _unitOfWork.TableRepository<TbImage>().ResetRange(imagesEntities, userId , x => x.ItemId == itemId);

                var commitResult = await _unitOfWork.Commit();
                return commitResult == 0;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error saving item", ex);
            }
        }
        private async Task ProcessImages(ItemDto dto)
        {
            if (dto.ImageBackGround != null)
            {
                var bytes = await _fileUploadService.GetFileBytesAsync(dto.ImageBackGround);
                dto.ImagePathBackGround = await ProcessAndUploadImage(bytes, dto.ImagePathBackGround, "Images");
            }

            if (dto.Images == null) return;

            foreach (var imageDto in dto.Images)
            {
                if (imageDto.Image == null) continue;
                var bytes = await _fileUploadService.GetFileBytesAsync(imageDto.Image);
                imageDto.ImagePath = await ProcessAndUploadImage(bytes, imageDto.ImagePath, "Images", isProcess: false);
            }
        }
        private async Task<string> ProcessAndUploadImage(byte[] imageBytes, string? oldImagePath, string folderName, bool isProcess = true)
        {
            string fileName = !string.IsNullOrWhiteSpace(oldImagePath) ? Path.GetFileName(oldImagePath) : null;

            if (isProcess)
            {
                var resized = _imageProcessingService.ResizeImage(imageBytes, 1024, 1024);
                //var webp = _imageProcessingService.ConvertToWebP(resized);
                return await _fileUploadService.UploadFileAsync(resized, folderName, fileName);
            }

            return await _fileUploadService.UploadFileAsync(imageBytes, folderName, fileName);
        }
        public IEnumerable<VwItemDto> GetSpecialOffers()
        {
            var entitiesList = _itemRepository.GetSpecialOffers();
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public IEnumerable<VwItemDto> GetNewItems()
        {
            var entitiesList = _itemRepository.GetNewItems();
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public IEnumerable<VwItemDto> GetRelatedItems(Guid Id)
        {
            var entitiesList = _itemRepository.GetRelatedItems(Id);
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public IEnumerable<VwItemDto> GetBestSellers()
        {
            var entitiesList = _itemRepository.GetBestSellers();
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public IEnumerable<VwItemDto> GetFeaturedProducts()
        {
            var entitiesList = _itemRepository.GetFeaturedProducts();
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public IEnumerable<VwItemDto> GetAllItems()
        {
            var entitiesList = _itemRepository.GetAll();
            var dtoList = _mapper.MapList<VwItem, VwItemDto>(entitiesList);
            return dtoList;
        }
        public VwItemDto Find(Guid id)
        {
            var entity = _itemRepository.Find(x => x.Id == id);
            var dto = _mapper.MapModel<VwItem, VwItemDto>(entity);
            return dto;
        }
        public bool IncrementSoldCount(IEnumerable<SoldItemDto> soldItems, Guid userId)
        {
            var ids = soldItems.Select(x => x.Id).ToList();
      
            var items = _unitOfWork.TableRepository<TbItem>().Get(x => ids.Contains(x.Id)).ToList();

            foreach (var item in items)
            {

                var soldItem = soldItems.FirstOrDefault(x => x.Id == item.Id);
                if (soldItem != null)
                {
                    item.SoldCount += soldItem.Qty;

                }
            }

            _unitOfWork.TableRepository<TbItem>().SaveRange(items, userId);
            return true;
        }
        public IEnumerable<ItemDto> GetWithDetails()
        {
            var entities = _unitOfWork.Repository<TbItem>()
                .Get(x => x.CurrentState ==1, 
                     x => x.Type);

            var dtoList = _mapper.MapList<TbItem, ItemDto>(entities);
            return dtoList;
        }
        public IEnumerable<VwItemWithTypeNameDto> GetItemsWithTypeName()
        {
            var entitiesList = _repository.GetAll();
            var dtoList = _mapper.MapList<VwItemWithTypeName, VwItemWithTypeNameDto>(entitiesList);
            return dtoList;
        }
        public PaginatedDataModel<VwItemWithTypeNameDto> GetAllItemsByPagination(
         int pageNumber = 1,
         int pageSize = 10,
         string? searchTerm = null,
         string? orderBy = null)
        {
            if (pageNumber == 0)
                pageNumber = 1;

            Expression<Func<VwItemWithTypeName, bool>> filter = x =>
                string.IsNullOrEmpty(searchTerm) || 
                (
                    (x.TitleAr != null && x.TitleAr.ToLower().Contains(searchTerm.ToLower())) ||
                    (x.TitleEn != null && x.TitleEn.ToLower().Contains(searchTerm.ToLower())) ||
                    (x.TypeTitleAr != null && x.TypeTitleAr.ToLower().Contains(searchTerm.ToLower())) ||
                    (x.TypeTitleEn != null && x.TypeTitleEn.ToLower().Contains(searchTerm.ToLower()))
                );

            Func<IQueryable<VwItemWithTypeName>, IOrderedQueryable<VwItemWithTypeName>>? orderByFunc = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderByFunc = q => q.OrderBy(orderBy);
            }

            var entitiesList = _repository.GetPage(pageNumber, pageSize, filter, orderByFunc);

            var dtoList = _mapper.MapList<VwItemWithTypeName, VwItemWithTypeNameDto>(entitiesList.Items);

            return new PaginatedDataModel<VwItemWithTypeNameDto>(dtoList, entitiesList.TotalRecords);
        }



    }
}

