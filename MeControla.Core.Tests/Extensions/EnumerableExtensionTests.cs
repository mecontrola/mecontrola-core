using FluentAssertions;
using MeControla.Core.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class EnumerableExtensionTests
    {
        private readonly TimeSpan EXPECTED_AVERAGE = new(11, 40, 0);
        private readonly TimeSpan EXPECTED_SUM = new(35, 0, 0);

        private readonly IList<TimeSpan> ACTUAL_LIST = new List<TimeSpan>
        {
             TimeSpan.FromHours(10), TimeSpan.FromHours(12), TimeSpan.FromHours(13)
        };

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable for nulo.")]
        public void DeveRetornarTrueEnumerableNull()
        {
            var list = (IEnumerable<string>)null;

            list.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable estiver vazio.")]
        public void DeveRetornarTrueEnumerableVazio()
        {
            var list = (IEnumerable<string>)new List<string>();

            list.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar false quando enumerable estiver preenchido.")]
        public void DeveRetornarFalseEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            list.IsNullOrEmpty().Should().BeFalse();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar false quando enumerable for nulo.")]
        public void DeveRetornarFalseEnumerableNull()
        {
            var list = (IEnumerable<string>)null;

            list.IsNotNullAndAny().Should().BeFalse();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar false quando enumerable estiver vazio.")]
        public void DeveRetornarFalseEnumerableVazio()
        {
            var list = (IEnumerable<string>)new List<string>();

            list.IsNotNullAndAny().Should().BeFalse();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar true quando enumerable estiver preenchido.")]
        public void DeveRetornarTrueEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            list.IsNotNullAndAny().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista for nula.")]
        public void DeveRetornarNullQuandoListNull()
        {
            var list = (IEnumerable<string>)null;

            list.ToListOrNull().Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            list.ToListOrNull().Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListPreenchida()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            list.ToListOrNull().Should().NotBeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista for nula.")]
        public void DeveRetornarNullQuandoListSelectNull()
        {
            var list = (IEnumerable<string>)null;

            list.SelectToListOrNull(itm => itm).Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListSelectVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            list.SelectToListOrNull(itm => itm).Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListSelectPreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            list.SelectToListOrNull(itm => itm).Should().NotBeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select com parâmetro index quando lista for nula.")]
        public void DeveRetornarNullQuandoListSelectIndexNull()
        {
            var list = (IEnumerable<string>)null;

            list.SelectToListOrNull((itm, index) => itm).Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar null ao utlizar Linq.Select com parâmetro index quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListSelectIndexVazia()
        {
            var list = (IEnumerable<string>)new List<string>();

            list.SelectToListOrNull((itm, index) => itm).Should().BeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrNull] Deve retornar lista ao utlizar Linq.Select com parâmetro index quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListSelectIndexPreenchido()
        {
            var list = (IEnumerable<string>)new List<string> { string.Empty };

            list.SelectToListOrNull((itm, index) => itm).Should().NotBeNull();
        }

        [Fact(DisplayName = "[EnumerableExtension.ForEach] Deve somar os valores utilizando Foreach para o IEnumerable.")]
        public void DeveSomarValoresIEnumerableForeach()
        {
            var list = (IEnumerable<int>)new List<int> { 1, 2, 3 };
            var expect = 6;
            var total = 0;

            list.ForEach(i => { total += i; });

            total.Should().Be(expect);
        }

        [Fact(DisplayName = "[EnumerableExtension.FindIndexAll] Deve retornar uma lista do indices de acordo com o Predicate.")]
        public void DeveRetornarListaIndicesPredicate()
        {
            var list = (IEnumerable<int>)new List<int> { 1, 2, 4, 5, 2, 2, 4 };
            var expected = new List<int> { 0, 3 };
            var actual = list.FindIndexAll(x => x % 2 != 0);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[Enumerable.Sum] Deve retornar a soma dos itens contidos em um lista de TimeSpan.")]
        public void DeveSomarValoresTimeSpan()
            => ACTUAL_LIST.Sum(x => x)
                          .Should()
                          .Be(EXPECTED_SUM);

        [Fact(DisplayName = "[Enumerable.Average] Deve retornar a média dos itens contidos em um lista de TimeSpan.")]
        public void DeveMediaValoresTimeSpan()
            => ACTUAL_LIST.Average(x => x)
                          .Should()
                          .Be(EXPECTED_AVERAGE);
    }
}