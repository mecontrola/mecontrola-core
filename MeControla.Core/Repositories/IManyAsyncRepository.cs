using MeControla.Core.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public interface IManyAsyncRepository<TEntity, TRoot, TTarget>
       where TEntity : IManyEntity<TRoot, TTarget>
       where TRoot : IEntity
       where TTarget : IEntity
    {
        Task<bool> CreateAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(TEntity obj, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(TEntity obj, CancellationToken cancellationToken);
    }
}