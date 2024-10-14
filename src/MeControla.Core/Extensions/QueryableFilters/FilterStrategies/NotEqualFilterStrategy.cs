using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the not equality filter strategy, which filters entities based on not equality comparisons.
/// </summary>
internal class NotEqualFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the not equality operation.
    /// </summary>
    public static string Name = "ne";

    /// <summary>
    /// Constructs the expression for an not equality comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the not equality comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.NotEqual(member, constant);
}