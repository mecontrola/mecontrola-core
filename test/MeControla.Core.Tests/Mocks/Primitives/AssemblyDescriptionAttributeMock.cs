using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyDescriptionAttributeMock
    {
        public static AssemblyDescriptionAttribute CreateEmpty()
            => new(null);

        public static AssemblyDescriptionAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}