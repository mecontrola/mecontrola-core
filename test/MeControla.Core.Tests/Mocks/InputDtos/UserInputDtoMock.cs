using MeControla.Core.Tests.Mocks.Datas.InputDtos;

namespace MeControla.Core.Tests.Mocks.InputDtos
{
    public static class UserInputDtoMock
    {
        public static UserInputDto CreateEmpty()
            => new();

        public static UserInputDto CreateUser1()
            => new()
            {
                Name = DataMock.TEXT_USER_NAME_1
            };
    }
}