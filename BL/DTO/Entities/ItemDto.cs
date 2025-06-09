using BL.CustomValidation;
using Domains.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Resources;
using Resources.Enumerations;
using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO.Entities
{
    public class ItemDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string TitleAr { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string TitleEn { get; set; } = null!;

        public string? ImagePathBackGround { get; set; }

        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".webp" })]
        [MaxFileSize(5)]
        public IFormFile? ImageBackGround { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "FieldLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string SerialNo { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 100000000, ErrorMessageResourceName = "PriceLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public decimal Price { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Range(1, 100, ErrorMessageResourceName = "DiscountPercentLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public decimal? DiscountPercent { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public Guid TypeId { get; set; }

        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
        public IEnumerable<TypeDto> Types { get; set; } = new List<TypeDto>();
        public DescriptionDto Description { get; set; } = new DescriptionDto();
    }
}
