using Resources;
using System.ComponentModel.DataAnnotations;

namespace Bl.DTO.User
{
    public class EmailLoginDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Email { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Password { get; set; } = null!;
    }
}