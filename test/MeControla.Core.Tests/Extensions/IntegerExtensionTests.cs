using FluentAssertions;
using MeControla.Core.Extensions;
using Xunit;

namespace MeControla.Core.Tests.Extensions;

public class IntegerExtensionTests
{
    [Fact(DisplayName = "[IntegerExtension.Pad] Deve adicionar zeros a esquerda do número.")]
    public void DeveAdicionarZerosAEsquerda()
    {
        var expected = "001234";
        var actual = 1234.Pad(6);

        actual.Should().Be(expected);
    }
}