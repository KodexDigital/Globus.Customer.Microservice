using System.ComponentModel.DataAnnotations;

namespace Globus.Core.Dtos
{
    public class OnboardCustomerDto
    {
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string StateOfResidence { get; set; }
        public string LGA { get; set; }
    }
}
