using System;
using System.Linq.Expressions;

namespace MeControla.Core.Extensions;

/// <summary>
/// Provides extension methods for working with Expression.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Combines two expressions into one using the logical AND operator.
    /// </summary>
    /// <typeparam name="T">The type of the data.</typeparam>
    /// <param name="source">The source expression.</param>
    /// <param name="target">The target expression.</param>
    /// <returns>A combined expression representing the logical AND of the two expressions.</returns>
    public static Expression<Func<T, bool>> Combine<T>(this Expression<Func<T, bool>> source, Expression<Func<T, bool>> target)
    {
        var parameter = Expression.Parameter(typeof(T));

        return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.Invoke(source, parameter), Expression.Invoke(target, parameter)), parameter);
    }
}