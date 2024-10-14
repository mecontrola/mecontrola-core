using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the ends with filter strategy, which filters entities based on ends with comparisons.
/// </summary>
internal class EndsWithFilterStrategy : BaseFilterStrategy
{
    /// <summary>
    /// The name of the ends with operation.
    /// </summary>
    internal const string Name = "ect";

    /// <summary>
    /// Constructs the expression for an ends with comparison between the member and the constant value.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the ends with comparison.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected override Expression MountExpression(MemberExpression member, ConstantExpression constant)
        => Expression.Call(member, "EndsWith", null, constant);
}