using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Contracts.Repositories.Custom;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SettingsService : BaseService<TbSettings, SettingsDto>, ISettingsService
    {
        private readonly ITableRepository<TbSettings> _baseTableRepository;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;

        public SettingsService(ITableRepository<TbSettings> baseTableRepository, IFileUploadService fileUploadService, IImageProcessingService imageProcessingService, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _mapper = mapper;
        }
        public async new Task<bool> Save(SettingsDto dto, Guid userId)
        {

            if (dto.Image != null)
            {
                var bytes = await _fileUploadService.GetFileBytesAsync(dto.Image);
                dto.Logo = await ProcessAndUploadImage(bytes, dto.Logo, "Images");
            }

            return base.Save(dto, userId);
        }

        private async Task<string> ProcessAndUploadImage(byte[] imageBytes, string? oldImagePath, string nameFolder)
        {
            //  Resize and convert image to WebP
            var resized = _imageProcessingService.ResizeImage(imageBytes, 1024, 1024);
            //var webp = _imageProcessingService.ConvertToWebP(resized);

            //  Extract old file name (if any)
            var oldFileName = !string.IsNullOrWhiteSpace(oldImagePath) ? Path.GetFileName(oldImagePath) : null;

            //  Upload new image and update path
            return await _fileUploadService.UploadFileAsync(resized, nameFolder, oldFileName);
        }

        public SettingsDto GetSettings()
        {

            var entity = _baseTableRepository.GetAll().FirstOrDefault();
            var dto = _mapper.MapModel<TbSettings, SettingsDto>(entity);
            return dto;
        }
    }
}
