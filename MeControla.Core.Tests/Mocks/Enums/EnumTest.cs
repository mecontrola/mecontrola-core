using System.ComponentModel;

namespace MeControla.Core.Tests.Mocks.Enums
{
    public enum EnumTest : uint
    {
        [Description("Test")]
        Element1 = 1,
        Element2 = 2
    }
}