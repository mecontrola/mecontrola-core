using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyProductAttributeMock
    {
        public static AssemblyProductAttribute CreateEmpty()
            => new(null);

        public static AssemblyProductAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}