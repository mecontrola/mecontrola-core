using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.Primitives;

public class IPaginationFilterMock
{
    public static IPagination CreateNull()
        => null;

    public static IPagination CreatePage1Size5()
        => new Pagination { Page = 1, Limit = 5 };
}