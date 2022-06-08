using Globus.Core.Entities;
using Globus.DAL.Data;
using Globus.DAL.Repositories.Declarations;

namespace Globus.DAL.Repositories.Implementations
{
    public class OneTimePasswordRepository : GlobalRepository<OneTimePassword>, IOneTimePasswordRepository
    {
        private readonly CustomerDbContext context;

        public OneTimePasswordRepository(CustomerDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
