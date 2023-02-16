using MeControla.Core.Data.Entities;

namespace MeControla.Core.Tests.Mocks.Datas.Entities
{
    public class PaginationFilter : IPaginationFilter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}