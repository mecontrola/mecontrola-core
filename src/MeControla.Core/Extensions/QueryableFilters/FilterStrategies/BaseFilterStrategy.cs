using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MeControla.Core.Extensions.QueryableFilters.FilterStrategies;

/// <summary>
/// Represents the base class for filter strategies that define how to apply filters to queryable sources.
/// </summary>
internal abstract class BaseFilterStrategy : IFilterStrategy
{
    /// <summary>
    /// Constructs the expression that defines the filter condition.
    /// </summary>
    /// <param name="member">The member expression representing the property to filter.</param>
    /// <param name="constant">The constant expression representing the value to compare against.</param>
    /// <returns>An expression representing the filter condition.</returns>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    protected abstract Expression MountExpression(MemberExpression member, ConstantExpression constant);

    /// <summary>
    /// Applies the filter to the specified queryable source based on the given property, operation, and value.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity being queried.</typeparam>
    /// <param name="query">The queryable source to which the filter will be applied.</param>
    /// <param name="property">The property of the entity to filter on.</param>
    /// <param name="operation">The filter operation to apply (e.g., "eq", "ne").</param>
    /// <param name="value">The value to compare the property against.</param>
    /// <returns>The queryable source with the applied filter.</returns>
    /// <remarks>
    /// This method creates a predicate expression that filters the queryable based on the specified criteria.
    /// The operation is defined by the derived class's implementation of <see cref="MountExpression"/>.
    /// </remarks>
    [RequiresUnreferencedCode("This method uses reflection, which may not be compatible with trimming.")]
    public IQueryable<TEntity> ApplyFilter<TEntity>(IQueryable<TEntity> query, string property, string operation, string value)
    {
        var type = typeof(TEntity);
        var parameter = Expression.Parameter(type, "x");

        if (type.GetProperty(property, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            throw new ArgumentException($"Property '{property}' does not exist.");

        var member = Expression.Property(parameter, property);
        var constant = CreateConstant(member.Type, value);
        var body = MountExpression(member, constant);
        var predicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
        return query.Where(predicate);
    }

    /// <summary>
    /// Creates a constant expression for the specified type and value.
    /// </summary>
    /// <param name="type">The type of the constant to create.</param>
    /// <param name="value">The value to convert to the specified type.</param>
    /// <returns>A constant expression representing the specified value.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the value cannot be converted to the specified type.</exception>
    [RequiresUnreferencedCode("This method uses reflection to create a constant expression.")]
    private static ConstantExpression CreateConstant(Type type, string value)
    {
        var converter = TypeDescriptor.GetConverter(type);

        if (!converter.IsValid(value))
            throw new InvalidOperationException($"Cannot convert value to type {type.Name}.");

        var convertedValue = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        return Expression.Constant(convertedValue, type);
    }
}