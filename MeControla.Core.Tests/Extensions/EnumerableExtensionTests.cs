using MeControla.Core.Extensions;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class EnumerableExtensionTests
    {
        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable for nulo.")]
        public void DeveRetornarTrueEnumerableNull()
        {
            var list = (IEnumerable<string>)null;

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable estiver vazio.")]
        public void DeveRetornarTrueEnumerableVazio()
        {
            var list = (IEnumerable<string>)new List<string>();

            Assert.True(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar false quando enumerable estiver preenchido.")]
        public void DeveRetornarFalseEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            Assert.False(list.IsNullOrEmpty());
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar false quando enumerable for nulo.")]
        public void DeveRetornarFalseEnumerableNull()
        {
            var list = (IEnumerable<string>)null;

            Assert.False(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar false quando enumerable estiver vazio.")]
        public void DeveRetornarFalseEnumerableVazio()
        {
            var list = (IEnumerable<string>)new List<string>();

            Assert.False(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar true quando enumerable estiver preenchido.")]
        public void DeveRetornarTrueEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            Assert.True(list.IsNotNullAndAny());
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista for nula.")]
        public void DeveRetornarNullQuandoListNull()
        {
            var list = (IEnumerable<string>)null;

            Assert.Null(list.ToListOrNull());
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            Assert.Null(list.ToListOrNull());
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListPreenchida()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            Assert.NotNull(list.ToListOrNull());
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista for nula.")]
        public void DeveRetornarNullQuandoListSelectNull()
        {
            var list = (IEnumerable<string>)null;

            Assert.Null(list.SelectToListOrNull(itm => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListSelectVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            Assert.Null(list.SelectToListOrNull(itm => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListSelectPreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            Assert.NotNull(list.SelectToListOrNull(itm => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select com parâmetro index quando lista for nula.")]
        public void DeveRetornarNullQuandoListSelectIndexNull()
        {
            var list = (IEnumerable<string>)null;

            Assert.Null(list.SelectToListOrNull((itm, index) => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select com parâmetro index quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListSelectIndexVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            Assert.Null(list.SelectToListOrNull((itm, index) => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select com parâmetro index quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListSelectIndexPreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            Assert.NotNull(list.SelectToListOrNull((itm, index) => itm));
        }

        [Fact(DisplayName = "[EnumerableExtension.ForEach] Deve somar os valores utilizando Foreach para o IEnumerable.")]
        public void DeveSomarValoresIEnumerableForeach()
        {
            var list = (IEnumerable<int>)new List<int> { 1, 2, 3 };
            var expect = 6;
            var total = 0;

            list.ForEach(i => { total += i; });

            Assert.Equal(expect, total);
        }

        [Fact(DisplayName = "[EnumerableExtension.FindIndexAll] Deve retornar uma lista do indices de acordo com o Predicate.")]
        public void DeveRetornarListaIndicesPredicate()
        {
            var list = (IEnumerable<int>)new List<int> { 1, 2, 4, 5, 2, 2, 4 };
            var expected = new List<int> { 0, 3 };
            var actual = list.FindIndexAll(x => x % 2 != 0);

            Assert.Equal(expected, actual);
        }
    }
}