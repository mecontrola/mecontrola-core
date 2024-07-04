using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class IEnumerableMock
    {
        public static IEnumerable<string> CreateFill()
            => DataMock.List456.Select(x => $"{DataMock.VALUE_DEFAULT_TEXT}{x}");
    }
}