﻿using Microsoft.AspNetCore.Http;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.CustomValidation
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!_extensions.Contains(extension))
                {
                    //return new ValidationResult($"Only {string.Join(", ", _extensions)} file formats are allowed.");
                    return new ValidationResult($"{ValidationResources.InvalidFormat}");

                }
            }
            return ValidationResult.Success;
        }
    }

}
