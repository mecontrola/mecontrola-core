using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyCompanyAttributeMock
    {
        public static AssemblyCompanyAttribute CreateEmpty()
            => new(null);

        public static AssemblyCompanyAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}