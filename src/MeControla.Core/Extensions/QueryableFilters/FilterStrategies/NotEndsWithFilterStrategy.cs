using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the not ends with filter strategy, which filters entities based on not ends with comparisons.
/// </summary>
internal class NotEndsWithFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the not ends with operation.
    /// </summary>
    public static string Name = "nect";

    /// <summary>
    /// Constructs the expression for an not ends with comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the not ends with comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Not(Expression.Call(member, "EndsWith", null, constant));
}