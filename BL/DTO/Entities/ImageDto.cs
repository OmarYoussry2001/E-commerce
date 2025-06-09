using BL.CustomValidation;
using Microsoft.AspNetCore.Http;
using Resources;
using Shared.DTOs.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace BL.DTO.Entities
{
    public class ImageDto : BaseDto
    {
        public string? ImagePath { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public Guid ItemId { get; set; }

        [AllowedExtensions(new[] { ".jpg", ".jpeg", ".png", ".webp" })]
        [MaxFileSize(5)]
        public IFormFile? Image { get; set; }
    }
}
