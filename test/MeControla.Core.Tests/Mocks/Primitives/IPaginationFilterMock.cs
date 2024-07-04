using MeControla.Core.Data.Entities;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Primitives
{
    public class IPaginationFilterMock
    {
        public static IPaginationFilter CreateNull()
            => (IPaginationFilter)null;

        public static IPaginationFilter CreatePage1Size5()
            => new PaginationFilter { PageNumber = 1, PageSize = 5 };
    }
}