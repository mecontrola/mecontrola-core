using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories;

public interface IUserRepository : IAsyncRepository<User>
{ }