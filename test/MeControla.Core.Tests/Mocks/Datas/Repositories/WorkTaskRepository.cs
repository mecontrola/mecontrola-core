using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Dtos;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories;

public sealed class WorkTaskRepository(IDbAppContext context)
    : BaseFilterAsyncRepository<WorkTask, WorkTaskFilter>(context, context.WorkTasks), IWorkTaskRepository
{
    public async override Task<IList<WorkTask>> FindFilterAllAsync(WorkTaskFilter filter, CancellationToken cancellationToken)
    {
        if (filter == null)
            return [];

        return await DbSet.AsNoTracking()
                          .Where(entity => filter != null
                                        && string.IsNullOrWhiteSpace(filter.Description) || (!string.IsNullOrWhiteSpace(filter.Description) && entity.Description.Contains(filter.Description, StringComparison.CurrentCultureIgnoreCase)))
                          .ToListAsync(cancellationToken);
    }
}