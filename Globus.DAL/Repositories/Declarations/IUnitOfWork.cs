namespace Globus.DAL.Repositories.Declarations
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        Task<int> ExecuteCommandAsync();
    }
}
