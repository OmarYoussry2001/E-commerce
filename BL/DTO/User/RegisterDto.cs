using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Resources;
using Shared.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Bl.DTO.User
{
    public class RegisterDto : BaseDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailInvalid", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string FirstName { get; set; } = null!; 
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string City { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessageResourceName = "PasswordConfirmation_Mismatch", ErrorMessageResourceType = typeof(UserResources))]
        [Compare(nameof(Password), ErrorMessageResourceName = "PasswordConfirmation_Mismatch", ErrorMessageResourceType = typeof(UserResources))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; } = "";
        [ValidateNever]
        public string Role { get; set; }
        [ValidateNever]
        public IEnumerable<IdentityRole> Roles { get; set; }


    }
}
