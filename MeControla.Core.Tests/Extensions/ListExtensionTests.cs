using MeControla.Core.Extensions;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class ListExtensionTests
    {
        [Fact(DisplayName = "[ListExtension.IsNullOrEmpty] Deve retornar true quando a lista for nula.")]
        public void DeveRetornarVerdadeiroQuandoNulo()
        {
            var list = (List<string>)null;

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[ListExtension.IsNullOrEmpty] Deve retornar true quando a lista estiver vazia.")]
        public void DeveRetornarVerdadeiroQuandoVazio()
        {
            var list = new List<string> { };

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[ListExtension.IsNullOrEmpty] Deve retornar false quando a lista estiver preenchido.")]
        public void DeveRetornarFalsoQuandoPreenchido()
        {
            var list = new List<string> { "Teste" };

            Assert.False(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[ListExtension.IsNotNullAndAny] Deve retornar false quando a lista for nula.")]
        public void DeveRetornarFalsoQuandoNulo()
        {
            var list = (List<string>)null;

            Assert.False(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[ListExtension.IsNotNullAndAny] Deve retornar false quando a lista estiver vazia.")]
        public void DeveRetornarFalsoQuandoVazio()
        {
            var list = new List<string> { };

            Assert.False(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[ListExtension.IsNotNullAndAny] Deve retornar true quando a lista estiver preenchido.")]
        public void DeveRetornarVerdadeiroQuandoPreenchido()
        {
            var list = new List<string> { "Teste" };

            Assert.True(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[ListExtension.ToListOrNull] Deve retornar null quando a lista for nula.")]
        public void DeveRetornarNuloQuandoNulo()
        {
            var list = (List<string>)null;

            Assert.Null(list.ToListOrNull());
        }

        [Fact(DisplayName = "[ListExtension.ToListOrNull] Deve retornar null quando a lista estiver vazia.")]
        public void DeveRetornarNuloQuandoVazio()
        {
            var list = new List<string> { };

            Assert.Null(list.ToListOrNull());
        }

        [Fact(DisplayName = "[ListExtension.ToListOrNull] Deve retornar a lista quando a lista estiver preenchido.")]
        public void DeveRetornarPreenchidoQuandoPreenchido()
        {
            var list = new List<string> { "Teste" };

            Assert.NotNull(list.ToListOrNull());
        }
    }
}