using BL.CustomValidation;
using Microsoft.AspNetCore.Http;
using Resources;
using Resources.Enumerations;
using Shared.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace BL.DTO.Entities
{
    public class TypeDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "AddressLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(TitleAr), ResourceType = typeof(FormResources))]
        public string TitleAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "AddressLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = nameof(TitleEn), ResourceType = typeof(FormResources))]
        public string TitleEn { get; set; } = null!;

        public string Title => ResourceManager.CurrentLanguage == Language.Arabic ? TitleAr : TitleEn;

        public string? ImagePath { get; set; }

        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".webp" })]
        [MaxFileSize(5)]
        public IFormFile? Image { get; set; }
    }
}
