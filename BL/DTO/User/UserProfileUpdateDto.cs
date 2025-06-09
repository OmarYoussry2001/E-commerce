using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.DTO.User
{
    public class UserProfileUpdateDto
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [EmailAddress(ErrorMessageResourceName = "EmailFormat", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Email { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(15, MinimumLength = 10, ErrorMessageResourceName = "MobileLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string PhoneNumber { get; set; } = null!;
    }
}
