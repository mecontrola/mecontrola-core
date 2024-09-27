using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Entities;

public class PaginationMock
{
    public static IPagination CreateNull()
        => null;

    public static IPagination CreatePage1()
        => new Pagination
        {
            Page = 1,
            Limit = 10,
        };

    public static IPagination CreatePage2()
        => new Pagination
        {
            Page = 2,
            Limit = 10,
        };

    public static IPagination CreateLast()
        => new Pagination
        {
            Page = 10,
            Limit = 10,
        };
}