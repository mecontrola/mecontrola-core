using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Entities
{
    public static class UserMock
    {

        public static User CreateUser1()
        {
            var dev = BaseUser();
            dev.Id = DataMock.INT_ID_1;
            dev.Uuid = DataMock.UUID_USER_1;
            dev.Name = DataMock.TEXT_USER_NAME_1;
            return dev;
        }

        public static User CreateUser2()
        {
            var dev = BaseUser();
            dev.Id = DataMock.INT_ID_2;
            dev.Uuid = DataMock.UUID_USER_2;
            dev.Name = DataMock.TEXT_USER_NAME_2;
            return dev;
        }

        public static User CreateUser3()
        {
            var dev = BaseUser();
            dev.Id = DataMock.INT_ID_3;
            dev.Uuid = DataMock.UUID_USER_3;
            dev.Name = DataMock.TEXT_USER_NAME_3;
            return dev;
        }

        public static User CreateUser4()
        {
            var dev = BaseUser();
            dev.Id = DataMock.INT_ID_4;
            dev.Uuid = DataMock.UUID_USER_4;
            dev.Name = DataMock.TEXT_USER_NAME_4;
            return dev;
        }

        private static User BaseUser()
            => new();

        public static IList<User> CreateList()
            => new List<User>
            {
                CreateUser1(),
                CreateUser2(),
                CreateUser3()
            };
    }
}