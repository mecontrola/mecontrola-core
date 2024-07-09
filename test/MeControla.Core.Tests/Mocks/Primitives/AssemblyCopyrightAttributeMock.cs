using System.Reflection;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class AssemblyCopyrightAttributeMock
    {
        public static AssemblyCopyrightAttribute CreateEmpty()
            => new(null);

        public static AssemblyCopyrightAttribute Create()
            => new(DataMock.TEXT_ASSEMBLY_NAME);
    }
}