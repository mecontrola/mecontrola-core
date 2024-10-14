using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the contract for defining and applying filtering logic to a queryable source.
/// </summary>
internal interface IFilterStrategy
{
    /// <summary>
    /// Applies the filtering logic to the provided queryable source based on a specified field, operator, and value.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to which the filter will be applied.</typeparam>
    /// <param name="query">The queryable source to which the filter will be applied.</param>
    /// <param name="property">The name of the field on which the filter will be applied.</param>
    /// <param name="operation">The comparison operator to be used in the filter (e.g., "eq", "ne", "lt", etc.).</param>
    /// <param name="value">The value to compare the field against.</param>
    /// <returns>The filtered queryable source.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    IQueryable<TEntity> ApplyFilter<TEntity>(IQueryable<TEntity> query, string property, string operation, string value);
}