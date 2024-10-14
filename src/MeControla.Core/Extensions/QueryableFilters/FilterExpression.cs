namespace MeControla.Core.Extensions.QueryableFilters;

/// <summary>
/// Represents a filter field, operation and value.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FilterExpression"/> class.
/// </remarks>
/// <param name="property">The name of the field to filter by.</param>
/// <param name="operation">The filter opreation (e.g., "eq", "ne", "lt", etc.).</param>
/// <param name="value">The value to filter apply.</param>
internal sealed class FilterExpression(string property, string operation, string value)
{
    /// <summary>
    /// Gets the name of the field to filter by.
    /// </summary>
    public string Property { get; } = property;

    /// <summary>
    /// Gets the filter operation (e.g., "eq", "ne", "lt", etc.).
    /// </summary>
    public string Operation { get; } = operation;

    /// <summary>
    /// Gets the sorting direction (asc/desc).
    /// </summary>
    public string Value { get; } = value;
}