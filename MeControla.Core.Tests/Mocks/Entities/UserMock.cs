using MeControla.Core.Data.Entities;
using System;
using System.Collections.Generic;
using data = MeControla.Core.Tests.Mocks.Datas.UserData;

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
            dev.Id = data.Id_Dev_1;
            dev.Uuid = data.Uuid_Dev_1;
            dev.Name = data.Name_Dev_1;
            return dev;
        }

        public static User CreateUser2()
        {
            var dev = BaseUser();
            dev.Id = data.Id_Dev_2;
            dev.Uuid = data.Uuid_Dev_2;
            dev.Name = data.Name_Dev_2;
            return dev;
        }

        public static User CreateUser3()
        {
            var dev = BaseUser();
            dev.Id = data.Id_Dev_3;
            dev.Uuid = data.Uuid_Dev_3;
            dev.Name = data.Name_Dev_3;
            return dev;
        }

        private static User BaseUser()
            => new User();
    }

    public class User : IEntity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public string Name { get; set; }
    }
}