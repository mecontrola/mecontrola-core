using MeControla.Core.Repositories;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Repositories
{
    public class UserPermissionRepository : BaseManyAsyncRepository<UserPermission, User, Permission>, IUserPermissionRepository
    {
        public UserPermissionRepository(IDbAppContext context)
            : base(context, context.UserPermissions)
        { }
    }
}