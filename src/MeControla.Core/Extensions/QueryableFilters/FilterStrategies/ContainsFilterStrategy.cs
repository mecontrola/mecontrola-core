using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the contains filter strategy, which filters entities based on contains comparisons.
/// </summary>
internal class ContainsFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the contains operation.
    /// </summary>
    public static string Name = "ct";

    /// <summary>
    /// Constructs the expression for an contains comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the contains comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Call(member, "Contains", null, constant);
}