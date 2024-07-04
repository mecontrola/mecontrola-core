using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Entities
{
    public class UserPermissionMock
    {
        public static UserPermission CreateUser1Administrator()
            => new()
            {
                RootId = DataMock.INT_ID_1,
                TargetId = DataMock.INT_ID_1,
            };

        public static UserPermission CreateUser2User()
            => new()
            {
                RootId = DataMock.INT_ID_2,
                TargetId = DataMock.INT_ID_2,
            };

        public static UserPermission CreateUser3User()
            => new()
            {
                RootId = DataMock.INT_ID_3,
                TargetId = DataMock.INT_ID_2,
            };

        public static IList<UserPermission> CreateList()
            => new List<UserPermission>
            {
                CreateUser1Administrator(),
                CreateUser2User(),
            };
    }
}