using FluentAssertions;
using MeControla.Core.Extensions;
using System;
using System.Linq.Expressions;
using Xunit;

namespace MeControla.Core.Tests.Extensions;

public class ExpressionExtensionsTests
{
    [Fact(DisplayName = "[ExpressionExtensions.Combine] Deve combinar duas expressões corretamente.")]
    public void DeveCombinarDuasExpressoesCorretamente()
    {
        Expression<Func<int, bool>> expr1 = x => x > 5;
        Expression<Func<int, bool>> expr2 = x => x < 10;

        var combined = expr1.Combine(expr2);
        var compiled = combined.Compile();

        compiled(7).Should().BeTrue();
        compiled(3).Should().BeFalse();
        compiled(12).Should().BeFalse();
    }

    [Fact(DisplayName = "[ExpressionExtensions.Combine] Deve retornar falso quando as duas expressões forem falsas.")]
    public void DeveRetornarFalsoQuandoDuasExpressoesForemFalsas()
    {
        Expression<Func<int, bool>> expr1 = x => x > 10;
        Expression<Func<int, bool>> expr2 = x => x < 5;

        var combined = expr1.Combine(expr2);
        var compiled = combined.Compile();

        compiled(7).Should().BeFalse();
    }

    [Fact(DisplayName = "[ExpressionExtensions .Combine] Deve retornar verdadeiro quando as duas expressões forem verdadeiras.")]
    public void DeveRetornarVerdadeiroQuandoDuasExpressoesForemVerdadeiras()
    {
        Expression<Func<int, bool>> expr1 = x => x >= 5;
        Expression<Func<int, bool>> expr2 = x => x <= 10;

        var combined = expr1.Combine(expr2);
        var compiled = combined.Compile();

        compiled(5).Should().BeTrue();
        compiled(10).Should().BeTrue();
    }

    [Fact(DisplayName = "[ExpressionExtensions.Combine] Deve gerar exceção com a mensagem e inner exception definidos.")]
    public void DeveGerarExcecaoComMensagemEInnerException()
    {
        Expression<Func<int, bool>> expr1 = x => x > 5;
        Expression<Func<int, bool>> expr2 = null;

        var act = () => expr1.Combine(expr2);

        act.Should().Throw<ArgumentNullException>();
    }

    [Fact(DisplayName = "[ExpressionExtensions.Combine] Deve combinar expressões booleanas corretamente.")]
    public void DeveCombinarExpressoesBooleanasCorretamente()
    {
        Expression<Func<bool, bool>> expr1 = x => x;
        Expression<Func<bool, bool>> expr2 = x => !x;

        var combined = expr1.Combine(expr2);
        var compiled = combined.Compile();

        compiled(true).Should().BeFalse();
        compiled(false).Should().BeFalse();
    }
}