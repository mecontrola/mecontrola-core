using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyFileVersionAttributeMock
    {
        public static AssemblyFileVersionAttribute CreateEmpty()
            => new(string.Empty);

        public static AssemblyFileVersionAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}