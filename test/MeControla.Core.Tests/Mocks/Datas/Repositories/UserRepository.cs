using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories;

public class UserRepository(IDbAppContext context)
    : BaseAsyncRepository<User>(context), IUserRepository
{ }