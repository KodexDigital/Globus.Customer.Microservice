using Globus.Core.Entities;
using Globus.DAL.Data;
using Globus.DAL.Repositories.Declarations;

namespace Globus.DAL.Repositories.Implementations
{
    public class CustomerRepository : GlobalRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext context;

        public CustomerRepository(CustomerDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
