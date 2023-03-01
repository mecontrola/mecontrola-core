using FluentAssertions;
using MeControla.Core.Tests.Mocks.Datas.Repositories;
using MeControla.Core.Tests.Mocks.Repositories;
using Xunit;

namespace MeControla.Core.Tests.Repositories
{
    public class ContextRepositoryTests : BaseRepository
    {
        private readonly IUserRepository repository;

        public ContextRepositoryTests()
            => repository = new UserRepository(context);

        [Fact(DisplayName = "ContextRepository.Database")]
        public void DeveChamar()
        {
            var actual = repository.Database();

            actual.Should().NotBeNull();
        }
    }
}