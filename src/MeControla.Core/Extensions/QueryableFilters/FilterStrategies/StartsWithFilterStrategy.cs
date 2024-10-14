using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the starts with filter strategy, which filters entities based on starts with comparisons.
/// </summary>
internal class StartsWithFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the starts with operation.
    /// </summary>
    internal const string Name = "sct";

    /// <summary>
    /// Constructs the expression for an starts with comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the starts with comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Call(member, "StartsWith", null, constant);
}