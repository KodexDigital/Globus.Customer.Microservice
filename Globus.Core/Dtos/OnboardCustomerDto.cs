using System.ComponentModel.DataAnnotations;

namespace Globus.Core.Dtos
{
    public class OnboardCustomerDto
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Eamil address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "State of residence is required")]
        public string StateOfResidence { get; set; }

        [Required]
        public string LGA { get; set; }
    }
}
