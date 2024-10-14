using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the less than filter strategy, which filters entities based on equal comparisons.
/// </summary>
internal class LessThanFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the less than operation.
    /// </summary>
    public static string Name = "lt";
    /// <summary>
    /// Constructs the expression for an less than comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the less than comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.LessThan(member, constant);
}