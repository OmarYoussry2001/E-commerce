using BL.CustomValidation;
using Microsoft.AspNetCore.Http;
using Resources;
using Resources.Enumerations;
using Shared.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace BL.DTO.Entities
{
    public class SliderDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(TitleAr), ResourceType = typeof(FormResources))]
        public string TitleAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(TitleEn), ResourceType = typeof(FormResources))]
        public string TitleEn { get; set; } = null!;

        public string Title => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 10, ErrorMessageResourceName = "RangeDisplayOrder", ErrorMessageResourceType = typeof(ValidationResources))]
        public int DisplayOrder { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionArLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(DescriptionAr), ResourceType = typeof(FormResources))]
        public string DescriptionAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionEnLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(DescriptionEn), ResourceType = typeof(FormResources))]
        public string DescriptionEn { get; set; } = null!;

        public string Description => ResourceManager.CurrentLanguage == Language.Arabic ? DescriptionAr : DescriptionEn;

        public string? ImagePath { get; set; }

        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".webp" })]
        [MaxFileSize(5)]
        public IFormFile? Image { get; set; }
    }
}
