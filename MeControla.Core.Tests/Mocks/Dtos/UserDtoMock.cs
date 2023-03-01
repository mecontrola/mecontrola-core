using MeControla.Core.Tests.Mocks.Datas.Dtos;

namespace MeControla.Core.Tests.Mocks.Dtos
{
    public static class UserDtoMock
    {
        public static UserDto CreateUser1()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_USER_1;
            obj.Name = DataMock.TEXT_USER_NAME_1;
            return obj;
        }

        public static UserDto CreateUser2()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_USER_2;
            obj.Name = DataMock.TEXT_USER_NAME_2;
            return obj;
        }

        public static UserDto CreateUser3()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_USER_3;
            obj.Name = DataMock.TEXT_USER_NAME_3;
            return obj;
        }

        private static UserDto BaseUser()
            => new();
    }
}