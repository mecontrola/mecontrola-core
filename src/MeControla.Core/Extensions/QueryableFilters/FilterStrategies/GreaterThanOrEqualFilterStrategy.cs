using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the greater than or equal filter strategy, which filters entities based on equal comparisons.
/// </summary>
internal class GreaterThanOrEqualFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the greater than or equal operation.
    /// </summary>
    internal const string Name = "gte";

    /// <summary>
    /// Constructs the expression for an greater than or equal comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the greater than or equal comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.GreaterThanOrEqual(member, constant);
}