using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the equality filter strategy, which filters entities based on equality comparisons.
/// </summary>
internal class EqualFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the equality operation.
    /// </summary>
    internal const string Name = "eq";

    /// <summary>
    /// Constructs the expression for an equality comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the equality comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Equal(member, constant);
}