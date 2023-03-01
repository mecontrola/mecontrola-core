using MeControla.Core.Data.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Entities
{
    public class UserPermission : IManyEntity<User, Permission>
    {
        public long RootId { get; set; }
        public long TargetId { get; set; }
        public User Root { get; set; }
        public Permission Target { get; set; }
    }
}