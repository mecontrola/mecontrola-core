using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyTitleAttributeMock
    {
        public static AssemblyTitleAttribute CreateEmpty()
            => new(null);

        public static AssemblyTitleAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}