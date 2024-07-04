using FluentAssertions;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Filters;
using MeControla.Core.Tests.Mocks.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace MeControla.Core.Tests.Repositories
{
    public sealed class BaseFilterAsyncRepositoryTests : BaseRepository
    {
        private readonly IWorkTaskRepository workTaskRepository;

        public BaseFilterAsyncRepositoryTests()
            => workTaskRepository = new WorkTaskRepository(context);

        [Fact(DisplayName = "[BaseFilterAsyncRepository.FindFilterAllAsync] Deve implementar o método FindFilterAllAsync para realizar a filtragem das informações.")]
        public async Task FindFilterAllAsync_ShouldReturnListOfEntities()
        {
            var actual = await workTaskRepository.FindFilterAllAsync(WorkTaskFilterMock.CreateEmpty(), GetCancellationToken());

            actual.Should().NotBeNull();
            actual.Should().HaveCount(0);
        }
    }
}