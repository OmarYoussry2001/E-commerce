using BL.Contracts.GeneralService.CMS;
using BL.Contracts.IMapper;
using BL.Contracts.Services;
using BL.DTO.Entities;
using BL.DTO.Views;
using DAL.Contracts.Repositories.Generic;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SliderService : BaseService<TbSlider, SliderDto>, ISliderService
    {
        private readonly ITableRepository<TbSlider> _baseTableRepository;
        private readonly IBaseMapper _mapper;
        private readonly IFileUploadService _fileUploadService;
        private readonly IImageProcessingService _imageProcessingService;
      
        public SliderService(ITableRepository<TbSlider> baseTableRepository, IFileUploadService fileUploadService, IImageProcessingService imageProcessingService, IBaseMapper mapper) : base(baseTableRepository, mapper)
        {
            _baseTableRepository = baseTableRepository;
            _fileUploadService = fileUploadService;
            _imageProcessingService = imageProcessingService;
            _mapper = mapper;
        }
        public async new Task<bool> Save(SliderDto dto, Guid userId)
        {

            if (dto.Image != null)
            {
                var bytes =  await _fileUploadService.GetFileBytesAsync(dto.Image);    
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
