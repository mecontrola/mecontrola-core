using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public class UserRepository : BaseAsyncRepository<User>, IUserRepository
    {
        public UserRepository(IDbAppContext context)
            : base(context, context.Users)
        { }
    }
}