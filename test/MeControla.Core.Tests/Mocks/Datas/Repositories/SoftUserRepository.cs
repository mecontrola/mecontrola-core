using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories;

public class SoftUserRepository(IDbAppContext context)
    : BaseSoftAsyncRepository<SoftUser>(context, context.SoftUsers), ISoftUserRepository
{ }