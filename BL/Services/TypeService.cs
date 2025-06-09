using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.GeneralService.CMS;
using DAL.Contracts.Repositories.Generic;
using DAL.Models;
using Domains.Entities;
using Shared.GeneralModels.SearchCriteriaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TypeService : BaseService<TbType, TypeDto>, ITypeService
    {
        private readonly ITableRepository<TbType> _baseTableRepository;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;
        public TypeService(ITableRepository<TbType> baseTableRepository, IFileUploadService fileUploadService, IImageProcessingService imageProcessingService, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _mapper = mapper;
        }
        public async new Task<bool> Save(TypeDto dto, Guid userId)
        {

            if (dto.Image != null)
            {
                var bytes = await _fileUploadService.GetFileBytesAsync(dto.Image);
                dto.ImagePath = await ProcessAndUploadImage(bytes, dto.ImagePath, "Images");
            }

            return base.Save(dto, userId);
        }
        private async Task<string> ProcessAndUploadImage(byte[] imageBytes, string? oldImagePath, string nameFolder)
        {
            //  Resize and convert image to WebP
            var resized = _imageProcessingService.ResizeImage(imageBytes, 1024, 1024);
            var webp = _imageProcessingService.ConvertToWebP(resized);

            //  Extract old file name (if any)
            var oldFileName = !string.IsNullOrWhiteSpace(oldImagePath) ? Path.GetFileName(oldImagePath) : null;

            //  Upload new image and update path
            return await _fileUploadService.UploadFileAsync(webp, nameFolder, oldFileName);
        }

    }
}
