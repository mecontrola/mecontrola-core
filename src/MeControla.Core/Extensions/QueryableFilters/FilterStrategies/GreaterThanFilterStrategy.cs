using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the greater than filter strategy, which filters entities based on greater than comparisons.
/// </summary>
internal class GreaterThanFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the greater than operation.
    /// </summary>
    internal const string Name = "gt";

    /// <summary>
    /// Constructs the expression for an greater than comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the greater than comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.GreaterThan(member, constant);
}