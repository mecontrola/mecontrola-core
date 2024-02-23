using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Datas.Mocks.Enums;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        [Fact(DisplayName = "[EnumExtensions.GetCustomAttribute] Deve retornar o atributo customizado quando existir.")]
        public void DeveRetornarAtributoQuandoExistir()
        {
            var actual = EnumTest.Element1.GetDescription();
            actual.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "[EnumExtensions.GetCustomAttribute] Deve retornar null quando não existir atributo customizado.")]
        public void DeveRetornarNullQuandoAtributoInexistente()
        {
            var actual = EnumTest.Element2.GetDescription();
            actual.Should().BeNull();
        }
    }
}