namespace MeControla.Core.Extensions.QueryableSorts;

/// <summary>
/// Represents a sorting field and direction (asc/desc).
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="SortExpression"/> class.
/// </remarks>
/// <param name="property">The name of the field to sort by.</param>
/// <param name="direction">The sorting direction (asc or desc).</param>
internal sealed class SortExpression(string property, SortDirection direction)
{
    /// <summary>
    /// Gets the name of the field to sort by.
    /// </summary>
    public string Property { get; } = property;

    /// <summary>
    /// Gets the sorting direction (asc/desc).
    /// </summary>
    public SortDirection Direction { get; } = direction;
}