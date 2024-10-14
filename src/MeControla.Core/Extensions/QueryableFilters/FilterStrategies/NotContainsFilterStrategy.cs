using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the not contains filter strategy, which filters entities based on not contains comparisons.
/// </summary>
internal class NotContainsFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the not contains operation.
    /// </summary>
    public static string Name = "nct";

    /// <summary>
    /// Constructs the expression for an not contains comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the not contains comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Not(Expression.Call(member, "Contains", null, constant));
}