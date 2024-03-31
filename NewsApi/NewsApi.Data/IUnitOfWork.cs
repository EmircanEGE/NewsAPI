using Microsoft.EntityFrameworkCore.Storage;

namespace NewsApi.Data
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        Task CommitAsync(IDbContextTransaction transaction);
        Task<IDbContextTransaction> CreateTransactionAsync();
    }
}
