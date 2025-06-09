﻿using Resources;
using System.ComponentModel.DataAnnotations;

namespace Bl.DTO.User
{
    public class ResendActivationCodeDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(15, MinimumLength = 10, ErrorMessageResourceName = "MobileLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Mobile { get; set; } = null!;
    }
}
