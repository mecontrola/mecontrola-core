using MeControla.Core.Data.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public interface IManyAsyncRepository<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TEntity>
       where TEntity : IForeignKeysManyEntity
    {
        Task<bool> CreateAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken);
    }
}