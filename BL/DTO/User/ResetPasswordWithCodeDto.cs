using Resources;
using System.ComponentModel.DataAnnotations;

namespace Bl.DTO.User
{
    public class ResetPasswordWithCodeDto
    {
        /// <summary>
        /// The mobile number associated with the user account.
        /// </summary>
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(15, MinimumLength = 10, ErrorMessageResourceName = "MobileLength", ErrorMessageResourceType = typeof(ValidationResources))]
        public string Mobile { get; set; } = null!;

        /// <summary>
        /// The verification code sent to the user’s mobile number.
        /// </summary>
        [Required(ErrorMessage = "Verification code is required.")]
        public string VerificationCode { get; set; } = null!;

        /// <summary>
        /// The new password to set for the user account.
        /// </summary>
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(ValidationResources))]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string NewPassword { get; set; } = null!;
    }
}
