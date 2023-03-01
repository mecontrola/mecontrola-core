using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Entities
{
    public class PermissionMock
    {
        public static Permission CreateAdministrator()
            => new()
            {
                Id = DataMock.INT_ID_1,
                Uuid = DataMock.UUID_PERMISSION_1,
                Name = DataMock.TEXT_PERMISSION_NAME_1,
            };

        public static Permission CreateUser()
            => new()
            {
                Id = DataMock.INT_ID_2,
                Uuid = DataMock.UUID_PERMISSION_2,
                Name = DataMock.TEXT_PERMISSION_NAME_2,
            };

        public static IList<Permission> CreateList()
            => new List<Permission>
            {
                CreateAdministrator(),
                CreateUser(),
            };
    }
}