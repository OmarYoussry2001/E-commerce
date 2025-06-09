using Domains.Entities;
using Resources;
using Resources.Enumerations;
using Shared.DTOs.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace BL.DTO.Entities
{
    public class DescriptionDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Size { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string ColorAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string ColorEn { get; set; } = null!;

        public string Color => ResourceManager.CurrentLanguage == Language.Arabic ? ColorAr : ColorEn;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionArLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "DescriptionAr", ResourceType = typeof(FormResources))]
        public string BenefitDescriptionAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(1000, MinimumLength = 10, ErrorMessageResourceName = "DescriptionEnLength", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "DescriptionEn", ResourceType = typeof(FormResources))]
        public string BenefitDescriptionEn { get; set; } = null!;

        public string BenefitDescription => ResourceManager.CurrentLanguage == Language.Arabic ? BenefitDescriptionAr : BenefitDescriptionEn;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string QualityAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string QualityEn { get; set; } = null!;

        public string Quality => ResourceManager.CurrentLanguage == Language.Arabic ? QualityAr : QualityEn;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public Guid ItemId { get; set; }
    }
}
