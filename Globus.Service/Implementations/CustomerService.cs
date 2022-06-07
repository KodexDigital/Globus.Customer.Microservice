using Globus.Core.Dtos;
using Globus.Core.Entities;
using Globus.DAL.Repositories.Declarations;
using Globus.Service.Declarations;

namespace Globus.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repo;
        private readonly IUnitOfWork uow;

        public CustomerService(ICustomerRepository repo, IUnitOfWork uow)
        {
            this.repo = repo;
            this.uow = uow;
        }

        public async Task<bool> OnboardCusoter(OnboardCustomerDto dto)
        {
            var custExists = await uow.CustomerRepository.ExistAsync(c => c.PhoneNumber.ToLower().Equals(dto.PhoneNumber.ToLower()));
            if (custExists)
                throw new Exception("Customer already exists");

            //validate state and lga mapping

            repo.Add(new Customer 
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Password = dto.Password, //hash this
                StateOfResidence = dto.StateOfResidence,
                LGA = dto.LGA,
            });

            var result = await uow.ExecuteCommandAsync();

            if (result > 0)
                return true;

            return false;
        }
        public Task<List<Customer>> GetAllOnbordedCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
