using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class DictionaryExtensionTests
    {
        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary for null.")]
        public void DeveRetornaFalseQuandoDictionaryNull()
        {
            var arr = (Dictionary<int, string>)null;

            arr.HasAny().Should().BeFalse();
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary estiver vazio.")]
        public void DeveRetornaFalseQuandoDictionaryVazio()
        {
            var arr = new Dictionary<int, string>();

            arr.HasAny().Should().BeFalse();
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar true quando o Dictionary estiver preenchido.")]
        public void DeveRetornaFalseQuandoDictionaryPreenchido()
        {
            var arr = new Dictionary<int, string> { { DataMock.VALUE_DEFAULT_5, DataMock.VALUE_DEFAULT_TEXT } };

            arr.HasAny().Should().BeTrue();
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary for null e com criterio informado.")]
        public void DeveRetornaFalseQuandoDictionaryNullComPredicate()
        {
            var arr = (Dictionary<int, string>)null;

            arr.HasAny(x => x.Value == DataMock.VALUE_DEFAULT_TEXT).Should().BeFalse();
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary estiver vazio e com criterio informado.")]
        public void DeveRetornaFalseQuandoDictionaryVazioComPredicate()
        {
            var arr = new Dictionary<int, string>();

            arr.HasAny(x => x.Value == DataMock.VALUE_DEFAULT_TEXT).Should().BeFalse();
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar true quando o Dictionary estiver preenchido e com criterio informado.")]
        public void DeveRetornaFalseQuandoDictionaryPreenchidoComPredicate()
        {
            var arr = new Dictionary<int, string> { { DataMock.VALUE_DEFAULT_5, DataMock.VALUE_DEFAULT_TEXT } };

            arr.HasAny(x => x.Value == DataMock.VALUE_DEFAULT_TEXT).Should().BeTrue();
        }
    }
}