using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Entities
{
    public static class UserMock
    {
        public static IList<User> CreateList()
            => new List<User>
            {
                CreateUser1(),
                CreateUser2(),
                CreateUser3()
            };

        public static User CreateUser1()
        {
            var dev = BaseUser();
            dev.Id = DataMock.ID_DEV_1;
            dev.Uuid = DataMock.UUID_DEV_1;
            dev.Name = DataMock.NAME_DEV_1;
            return dev;
        }

        public static User CreateUser2()
        {
            var dev = BaseUser();
            dev.Id = DataMock.ID_DEV_2;
            dev.Uuid = DataMock.UUID_DEV_2;
            dev.Name = DataMock.NAME_DEV_2;
            return dev;
        }

        public static User CreateUser3()
        {
            var dev = BaseUser();
            dev.Id = DataMock.ID_DEV_3;
            dev.Uuid = DataMock.UUID_DEV_3;
            dev.Name = DataMock.NAME_DEV_3;
            return dev;
        }

        private static User BaseUser()
            => new();
    }
}