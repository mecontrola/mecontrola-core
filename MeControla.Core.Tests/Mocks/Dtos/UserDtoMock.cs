using MeControla.Core.Tests.Mocks.Datas.Dtos;

namespace MeControla.Core.Tests.Mocks.Dtos
{
    public static class UserDtoMock
    {
        public static UserDto CreateUser1()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_DEV_1;
            obj.Name = DataMock.NAME_DEV_1;
            return obj;
        }

        public static UserDto CreateUser2()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_DEV_2;
            obj.Name = DataMock.NAME_DEV_2;
            return obj;
        }

        public static UserDto CreateUser3()
        {
            var obj = BaseUser();
            obj.Id = DataMock.UUID_DEV_3;
            obj.Name = DataMock.NAME_DEV_3;
            return obj;
        }

        private static UserDto BaseUser()
            => new();
    }
}