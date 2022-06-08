using System.ComponentModel.DataAnnotations;

namespace Globus.Core.Dtos
{
    public class VerifyPhoneNumberDto
    {
        [Required(ErrorMessage = "Customer Id missing")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "OTP is required")]
        public string OTPValue { get; set; }
    }
}
