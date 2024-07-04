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

        private readonly IList<TimeSpan> ACTUAL_LIST = [
             TimeSpan.FromHours(10), TimeSpan.FromHours(12), TimeSpan.FromHours(13)
        ];

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable for nulo.")]
        public void DeveRetornarTrueEnumerableNull()
        {
            var list = (IEnumerable<string>)null;

            list.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar true quando enumerable estiver vazio.")]
        public void DeveRetornarTrueEnumerableVazio()
        {
            var list = (IEnumerable<string>)[];

            list.IsNullOrEmpty().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNullOrEmpty] Deve retornar false quando enumerable estiver preenchido.")]
        public void DeveRetornarFalseEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)[string.Empty];

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
            var list = (IEnumerable<string>)[];

            list.IsNotNullAndAny().Should().BeFalse();
        }

        [Fact(DisplayName = "[EnumerableExtension.IsNotNullAndAny] Deve retornar true quando enumerable estiver preenchido.")]
        public void DeveRetornarTrueEnumerablePreenchido()
        {
            var list = (IEnumerable<string>)[string.Empty];

            list.IsNotNullAndAny().Should().BeTrue();
        }

        [Fact(DisplayName = "[EnumerableExtension.ToListOrEmpty] Deve retornar lista vazia quando enumerable estiver estiver null.")]
        public void DeveRetornarListaVaziaQuandoListNull()
        {
            var list = (IEnumerable<string>)null;
            var actual = list.ToListOrEmpty();

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.ToListOrEmpty] Deve retornar lista vazia quando enumerable estiver estiver vazio.")]
        public void DeveRetornarListaVaziaQuandoListVazia()
        {
            var list = (IEnumerable<string>)[];
            var actual = list.ToListOrEmpty();

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.ToListOrEmpty] Deve retornar lista vazia quando enumerable estiver estiver preenchido.")]
        public void DeveRetornarListQuandoListPreenchida()
        {
            var list = (IEnumerable<string>)[string.Empty];
            var actual = list.ToListOrEmpty();

            actual.Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista vazia ao utlizar Linq.Select quando enumerable for null.")]
        public void DeveRetornarListaVaziaQuandoListSelectNull()
        {
            var list = (IEnumerable<string>)null;
            var actual = list.SelectToListOrEmpty(itm => itm);

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista vazia ao utlizar Linq.Select quando enumerable for vazio.")]
        public void DeveRetornarListaVaziaQuandoListSelectVazia()
        {
            var list = (IEnumerable<string>)[];
            var actual = list.SelectToListOrEmpty(itm => itm);

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista ao utlizar Linq.Select quando enumerable estiver preenchido.")]
        public void DeveRetornarListQuandoListSelectPreenchido()
        {
            var list = (IEnumerable<string>)[string.Empty];
            var actual = list.SelectToListOrEmpty(itm => itm);

            actual.Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista vazia ao utlizar Linq.Select com parâmetro index quando lista for nula.")]
        public void DeveRetornarNullQuandoListSelectIndexNull()
        {
            var list = (IEnumerable<string>)null;
            var actual = list.SelectToListOrEmpty((itm, index) => itm);

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista vazia ao utlizar Linq.Select com parâmetro index quando lista estiver vazia.")]
        public void DeveRetornarNullQuandoListSelectIndexVazia()
        {
            var list = (IEnumerable<string>)[];
            var actual = list.SelectToListOrEmpty((itm, index) => itm);

            actual.Should().NotBeNull();
            actual.Should().BeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.SelectToListOrEmpty] Deve retornar lista ao utlizar Linq.Select com parâmetro index quando lista estiver preenchida.")]
        public void DeveRetornarListQuandoListSelectIndexPreenchido()
        {
            var list = (IEnumerable<string>)[string.Empty];
            var actual = list.SelectToListOrEmpty((itm, index) => itm);

            actual.Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }

        [Fact(DisplayName = "[EnumerableExtension.ForEach] Deve somar os valores utilizando Foreach para o IEnumerable.")]
        public void DeveSomarValoresIEnumerableForeach()
        {
            var list = (IEnumerable<int>)[1, 2, 3];
            var expect = 6;
            var total = 0;

            list.ForEach(i => { total += i; });

            total.Should().Be(expect);
        }

        [Fact(DisplayName = "[EnumerableExtension.FindIndexAll] Deve retornar uma lista do indices de acordo com o Predicate.")]
        public void DeveRetornarListaIndicesPredicate()
        {
            var list = (IEnumerable<int>)[1, 2, 4, 5, 2, 2, 4];
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

        [Fact(DisplayName = "[EnumerableExtension.ToObservableCollection] Deve retornar null quando o IEnumerable for null.")]
        public void DeveRetornarNullQuandoIEnumerableNull()
        {
            var action = () => ((IEnumerable<int>)null).ToObservableCollection();
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "[EnumerableExtension.ToObservableCollection] Deve retornar ObservableCollection quando o IEnumerable estiver preenchido.")]
        public void DeveRetornarObservableCollectionQuandoIEnumerablePreenchido()
            => ACTUAL_LIST.ToObservableCollection()
                          .Should()
                          .NotBeEmpty();
    }
}