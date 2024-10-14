using System.ComponentModel;

namespace MeControla.Core.Extensions.QueryableSorts;

/// <summary>
/// Specifies the direction of sorting.
/// </summary>
internal enum SortDirection
{
    [Description("asc")]
    Ascending,
    [Description("desc")]
    Descending
}