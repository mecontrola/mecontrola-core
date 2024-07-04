using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class IListMock
    {
        public static IList<int> CreateIntList()
            => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}