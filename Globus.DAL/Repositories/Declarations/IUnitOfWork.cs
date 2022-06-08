namespace Globus.DAL.Repositories.Declarations
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOneTimePasswordRepository OneTimePasswordRepository { get; }
        Task<int> ExecuteCommandAsync();
    }
}
