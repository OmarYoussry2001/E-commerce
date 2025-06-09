using Resources;
using System.ComponentModel.DataAnnotations;

namespace Bl.DTO.User
{
    public class LoginDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string? ReturnUrl { get; set; }

        public bool RememberMe { get; set; }
    }
}