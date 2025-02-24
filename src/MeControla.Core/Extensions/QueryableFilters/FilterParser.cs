using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

namespace MeControla.Core.Extensions.QueryableFilters;

/// <summary>
/// Parses a filter string into a collection of FilterExpressions.
/// </summary>
internal static class FilterParser
{
    private static readonly TimeSpan REGEX_TIMEOUT = TimeSpan.FromSeconds(2);

    private const string REGEX_PROPERTY_KEY = "property";
    private const string REGEX_OPERATION_KEY = "operation";
    private const string REGEX_VALUE_KEY = "value";

    private const string REGEX_FILTER = $@"(?<{REGEX_PROPERTY_KEY}>\w+)(\[(?<{REGEX_OPERATION_KEY}>\w+)\])?=(?<{REGEX_VALUE_KEY}>.+)";

    private static Regex RegexFilter()
        => new(REGEX_FILTER, RegexOptions.None, REGEX_TIMEOUT);

    /// <summary>
    /// Parses the filterBy string into a list of FilterExpression objects.
    /// </summary>
    /// <param name="filterBy">The filter criteria as a string.</param>
    /// <returns>A list of FilterExpression objects representing the filter fields, operation, and value.</returns>
    public static IEnumerable<FilterExpression> Parse(string filterBy)
        => filterBy.Split(',')
                   .Select(ReadParts);

    /// <summary>
    /// Analyze the filterBy string part and check if the value provided is not in the correct format.
    /// </summary>
    /// <param name="filter">The filter criteria as a string.</param>
    /// <returns>A FilterExpression object representing the filter fields, operation, and value.</returns>
    /// <exception cref="ArgumentException">Thrown if filter format is incorrect.</exception>
    private static FilterExpression ReadParts(string filter)
    {
        var match = RegexFilter().Match(filter);
        if (!match.Success)
            throw new ArgumentException($"Invalid filter format: {filter}.");

        return new FilterExpression(
            match.GetValueOrDefault(REGEX_PROPERTY_KEY)!,
            match.GetValueOrDefault(REGEX_OPERATION_KEY, EqualFilterStrategy.Name)!,
            match.GetValueOrDefault(REGEX_VALUE_KEY)!
        );
    }
}