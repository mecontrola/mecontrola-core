using System;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Extensions.QueryableSorts;

/// <summary>
/// Parses a sort string into a collection of SortExpressions.
/// </summary>
internal static class SortParser
{
    private static readonly string SORTDIRECTION_DESC = SortDirection.Descending.GetDescription()!;

    /// <summary>
    /// Parses the sortBy string into a list of SortExpression objects.
    /// </summary>
    /// <param name="sortBy">The sorting criteria as a string.</param>
    /// <returns>A list of SortExpression objects representing the fields and sort directions.</returns>
    public static IEnumerable<SortExpression> Parse(string sortBy)
    {
        var sortParams = sortBy.Split(',');

        foreach (var param in sortParams)
        {
            var trimmedParam = param.Trim();
            var parts = trimmedParam.Split('_');
            var fieldName = parts[0];
            var direction = GetSortDirection(parts.ElementAtOrDefault(1) ?? string.Empty);

            yield return new SortExpression(fieldName, direction);
        }
    }

    /// <summary>
    /// Convert the string direction to <see cref="SortDirection"/>.
    ///If the direction provided is not equal to desc, the value asc will be considered.
    /// </summary>
    /// <param name="direction"></param>
    /// <returns>A <see cref="SortDirection"/> value.</returns>
    private static SortDirection GetSortDirection(string direction)
        => !direction.IsNullOrWhiteSpace() && direction.Equals(SORTDIRECTION_DESC, StringComparison.OrdinalIgnoreCase)
         ? SortDirection.Descending
         : SortDirection.Ascending;
}
