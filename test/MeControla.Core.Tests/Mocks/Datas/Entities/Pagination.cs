using System.Linq;

namespace MeControla.Core.Tests.Mocks.Datas.Entities;

public class Pagination : IPagination
{
    public long Page { get; set; }
    public long Limit { get; set; }
    public string FilterBy { get; set; }
    public string SortBy { get; set; }
}