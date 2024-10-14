using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the less than or equal filter strategy, which filters entities based on equal comparisons.
/// </summary>
internal class LessThanOrEqualFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the less than or equal operation.
    /// </summary>
    internal const string Name = "lte";

    /// <summary>
    /// Constructs the expression for an less than or equal comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the less than or equal comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.LessThanOrEqual(member, constant);
}