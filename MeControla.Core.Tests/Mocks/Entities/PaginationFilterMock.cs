using MeControla.Core.Data.Entities;
using MeControla.Core.Tests.Mocks.Datas.Entities;

namespace MeControla.Core.Tests.Mocks.Entities
{
    public class PaginationFilterMock
    {
        public static IPaginationFilter CreatePage1()
            => new PaginationFilter
            {
                PageNumber = 1,
                PageSize = 10,
            };

        public static IPaginationFilter CreatePage2()
            => new PaginationFilter
            {
                PageNumber = 2,
                PageSize = 10,
            };
    }
}