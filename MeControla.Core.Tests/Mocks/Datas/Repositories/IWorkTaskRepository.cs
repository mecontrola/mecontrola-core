using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Dtos;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public interface IWorkTaskRepository : IFilterAsyncRepository<WorkTask, WorkTaskFilter>
    { }
}