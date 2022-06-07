using Globus.DAL.Data;
using Globus.DAL.Repositories.Declarations;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using System.Text;

namespace Globus.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext context;
        public UnitOfWork(CustomerDbContext context) { this.context = context; }

        public ICustomerRepository CustomerRepository => new CustomerRepository(context);

        public async Task<int> ExecuteCommandAsync()
        {
            using var transaction = context.Database.BeginTransaction();
            try
            {
                int result = 0;
                var strategy = context.Database.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    result = await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                });

                return result;
            }
            catch (DbEntityValidationException dbvex)
            {
                var outputLines = new StringBuilder();

                foreach (var eve in dbvex.EntityValidationErrors)
                {
                    outputLines.AppendLine(
                        $"{DateTime.Now}: Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors: ");

                    foreach (var ve in eve.ValidationErrors)
                        outputLines.AppendLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                }

                transaction.Rollback();
                throw new DbEntityValidationException(outputLines.ToString(), dbvex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
