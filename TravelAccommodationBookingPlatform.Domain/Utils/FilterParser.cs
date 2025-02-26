﻿using System.Linq.Expressions;
using System.Reflection;

namespace TravelAccommodationBookingPlatform.Domain.Utils;
public class FilterParser<T>
{
    public static Expression<Func<T, bool>>? Parse(string filterString)
    {
        if (string.IsNullOrWhiteSpace(filterString))
            return null;

        var filters = filterString.Split(';');
        var parameter = Expression.Parameter(typeof(T), "x");

        Expression? finalExpression = null;

        foreach (var filter in filters)
        {
            var (propertyName, operatorString, valueString) = OperatorHandler.Parse(filter);
            if (propertyName == null || operatorString == null || valueString == null)
                continue;

            var property = typeof(T).GetProperty(
                propertyName,
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance
            );
            if (property == null)
                continue;

            var comparison = CreateComparisonExpression(
                parameter,
                property,
                operatorString,
                valueString
            );
            if (comparison == null)
                continue;

            finalExpression =
                finalExpression == null
                    ? comparison
                    : Expression.AndAlso(finalExpression, comparison);
        }

        return finalExpression == null
            ? null
            : Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
    }

    private static Expression? CreateComparisonExpression(
        Expression parameter,
        PropertyInfo property,
        string operatorString,
        string valueString
    )
    {
        object value;
        try
        {
            value = PropertyConverter.ConvertPropertyValue(property, valueString);
        }
        catch
        {
            return null;
        }

        var constant = Expression.Constant(value, property.PropertyType);
        var member = Expression.Property(parameter, property);

        return operatorString switch
        {
            ValidOperators.Equal => Expression.Equal(member, constant),
            ValidOperators.NotEquals => Expression.NotEqual(member, constant),
            ValidOperators.GreaterThan => Expression.GreaterThan(member, constant),
            ValidOperators.GreaterThanEqualTo => Expression.GreaterThanOrEqual(member, constant),
            ValidOperators.LessThan => Expression.LessThan(member, constant),
            ValidOperators.LessThanEqualTo => Expression.LessThanOrEqual(member, constant),
            ValidOperators.Contains
                => Expression.Call(member, nameof(string.Contains), null, constant),
            ValidOperators.DoesNotContains
                => Expression.Not(Expression.Call(member, nameof(string.Contains), null, constant)),
            ValidOperators.StartsWith
                => Expression.Call(member, nameof(string.StartsWith), null, constant),
            ValidOperators.DoesNotStartsWith
                => Expression.Not(
                    Expression.Call(member, nameof(string.StartsWith), null, constant)
                ),
            _ => null
        };
    }
}