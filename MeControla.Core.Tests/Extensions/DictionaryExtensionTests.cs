using MeControla.Core.Extensions;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class DictionaryExtensionTests
    {
        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary for null.")]
        public void DeveRetornaFalseQuandoDictionaryNull()
        {
            var arr = (Dictionary<string, string>)null;

            Assert.False(arr.HasAny());
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar false quando o Dictionary estiver vazio.")]
        public void DeveRetornaFalseQuandoDictionaryVazio()
        {
            var arr = new Dictionary<string, string>();

            Assert.False(arr.HasAny());
        }

        [Fact(DisplayName = "[DictionaryExtension.HasAny] Deve retornar true quando o Dictionary estiver preenchido.")]
        public void DeveRetornaFalseQuandoDictionaryPreenchido()
        {
            var arr = new Dictionary<string, string> { { "TKey", "TValue" } };

            Assert.True(arr.HasAny());
        }
    }
}