
using Resources;
using Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.DTO.User
{
    public class ApplicationUserDto : BaseDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Address { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(15, MinimumLength = 10, ErrorMessageResourceName = "MobileLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Guid? CompanyId { get; set; }
        //public TbCompany? Company { get; set; }
        [NotMapped]
        public string Role { get; set; }
    }
}
