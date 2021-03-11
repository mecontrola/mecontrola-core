using MeControla.Core.Data.Dtos;
using System;
using data = MeControla.Core.Tests.Mocks.Datas.UserData;

namespace MeControla.Core.Tests.Mocks.Dtos
{
    public static class UserDtoMock
    {
        public static UserDto CreateUser1()
        {
            var obj = BaseUser();
            obj.Id = data.Uuid_Dev_1;
            obj.Name = data.Name_Dev_1;
            return obj;
        }

        public static UserDto CreateUser2()
        {
            var obj = BaseUser();
            obj.Id = data.Uuid_Dev_2;
            obj.Name = data.Name_Dev_2;
            return obj;
        }

        public static UserDto CreateUser3()
        {
            var obj = BaseUser();
            obj.Id = data.Uuid_Dev_3;
            obj.Name = data.Name_Dev_3;
            return obj;
        }

        private static UserDto BaseUser()
            => new UserDto();
    }

    public class UserDto : IDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}