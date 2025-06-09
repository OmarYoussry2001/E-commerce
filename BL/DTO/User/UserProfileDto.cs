//using Resources;
//using Resources.Enumerations;
//using Shared.Attributes;
//using System.ComponentModel.DataAnnotations;

//namespace Bl.DTO.User
//{
//    public class UserProfileDto
//    {
//        public string Id { get; set; }

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(20, MinimumLength = 2, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        [RegularExpression(@"^[a-zA-Z\s\-']+$", ErrorMessageResourceName = "InvalidFormat", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string FirstName { get; set; } = null!;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(20, MinimumLength = 2, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        [RegularExpression(@"^[a-zA-Z\s\-']+$", ErrorMessageResourceName = "InvalidFormat", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string LastName { get; set; } = null!;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [EmailAddress(ErrorMessageResourceName = "InvalidFormat", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(100, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string Email { get; set; } = null!;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [CountrySpecificPhone(CountryField = nameof(Country), ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ValidationResources))]
//        [RegularExpression(@"^[0-9]+$", ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string PhoneNumber { get; set; } = null!;
       
//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(200, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string Address { get; set; } = null!;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [CountrySpecificNationalId(CountryField = nameof(Country), ErrorMessageResourceName = "InvalidNationalId", ErrorMessageResourceType = typeof(ValidationResources))]
//        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessageResourceName = "InvalidNationalId", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string NationalId { get; set; } = null!;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string CountryEn { get; set; } = null!;
//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string CountryAr { get; set; } = null!;
//        public string Country ()=>ResourceManager.CurrentLanguage==Language.Arabic? CountryAr:CountryEn;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string StateAr { get; set; } = null!;
//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string StateEn { get; set; } = null!;
//        public string State()=>ResourceManager.CurrentLanguage==Language.Arabic? StateAr : StateEn;

//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string CityAr { get; set; } = null!;
//        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
//        [StringLength(50, ErrorMessageResourceName = "OutOfMaxLength", ErrorMessageResourceType = typeof(ValidationResources))]
//        public string CityEn { get; set; } = null!;
//        public string City()=>ResourceManager.CurrentLanguage==Language.Arabic? CityAr : CityEn;

//        public string? Token { get; set; } = null!;
//        public string? RefreshToken { get; set; } = null!;
//    }
//}
