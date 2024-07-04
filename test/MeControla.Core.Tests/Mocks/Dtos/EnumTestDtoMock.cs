using MeControla.Core.Extensions;
using MeControla.Core.Tests.Datas.Mocks.Enums;
using MeControla.Core.Tests.Mocks.Datas.Dtos;

namespace MeControla.Core.Tests.Mocks.Dtos
{
    public static class EnumTestDtoMock
    {
        public static EnumTestDto CreateElement1()
            => new()
            {
                Id = (uint)EnumTest.Element1,
                Value = EnumTest.Element1.GetDescription(),
            };

        public static EnumTestDto CreateElement2()
            => new()
            {
                Id = (uint)EnumTest.Element2,
                Value = EnumTest.Element2.GetDescription(),
            };
    }
}