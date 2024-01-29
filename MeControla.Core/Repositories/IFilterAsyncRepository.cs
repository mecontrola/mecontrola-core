using MeControla.Core.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Repositories
{
    public interface IFilterAsyncRepository<TEntity, TFilterEntity> : IAsyncRepository<TEntity>
        where TEntity : class, IEntity
        where TFilterEntity : class, IFilterEntity
    {
        Task<IList<TEntity>> FindFilterAllAsync(TFilterEntity filter, CancellationToken cancellationToken);
    }
}