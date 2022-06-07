using Globus.Core.Dtos;
using Globus.Core.Entities;

namespace Globus.Service.Declarations
{
    public interface ICustomerService
    {
        Task<bool> OnboardCusoter(OnboardCustomerDto dto);
        Task<List<Customer>> GetAllOnbordedCustomers();
    }
}
