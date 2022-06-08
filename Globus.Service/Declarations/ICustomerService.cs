using Globus.Core.Common;
using Globus.Core.Dtos;
using Globus.Core.Entities;

namespace Globus.Service.Declarations
{
    public interface ICustomerService
    {
        Task<ResponseModel> OnboardCustomer(OnboardCustomerDto dto);
        Task<ResponseModel> VerifyPhoneNumberViaOTP(VerifyPhoneNumberDto dto);
        Task<ResponseModel<IEnumerable<Customer>>> GetAllOnbordedCustomers();
    }
}
