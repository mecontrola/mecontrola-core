using MeControla.Core.Tests.Mocks.Datas.Repositories;

namespace MeControla.Core.Tests.Mocks.Repositories
{
    public class UserRepositoryMock : BaseRepository
    {
        public static IUserRepository Create()
            => new UserRepository(GetDbInstance());
    }
}