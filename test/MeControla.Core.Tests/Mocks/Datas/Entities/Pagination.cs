using System.Linq;

namespace MeControla.Core.Tests.Mocks.Datas.Entities;

public class Pagination : IPagination
{
    public long Page { get; set; }
    public long Limit { get; set; }
}