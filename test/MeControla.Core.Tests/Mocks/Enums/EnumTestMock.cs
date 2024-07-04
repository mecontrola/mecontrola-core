using MeControla.Core.Tests.Datas.Mocks.Enums;

namespace MeControla.Core.Tests.Mocks.Enums
{
    public static class EnumTestMock
    {
        public static EnumTest CreateEmpty()
            => 0;

        public static EnumTest CreateElement1()
            => EnumTest.Element1;
    }
}