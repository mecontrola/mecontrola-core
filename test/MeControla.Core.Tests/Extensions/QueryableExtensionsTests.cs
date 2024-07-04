using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks.Primitives;
using System.Linq;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class QueryableExtensionsTests
    {
        [Fact(DisplayName = "[QueryableExtensions.SetPagination] Deve retornar a mesma lista quando a paginacao for null.")]
        public void DeveFazerNadaQuandoPaginacaoForNulo()
        {
            var actual = IListMock.CreateIntList()
                                  .AsQueryable()
                                  .SetPagination(IPaginationFilterMock.CreateNull())
                                  .ToList();


            actual.Count.Should().Be(10);
        }

        [Fact(DisplayName = "[QueryableExtensions.SetPagination] Deve filtrar as informações quando a paginacao for informarda.")]
        public void DeveFiltrarDadosQuandoPaginacaoInformado()
        {
            var actual = IListMock.CreateIntList()
                                  .AsQueryable()
                                  .SetPagination(IPaginationFilterMock.CreatePage1Size5())
                                  .ToList();


            actual.Count.Should().Be(5);
        }

        [Fact(DisplayName = "[QueryableExtensions.SetPredicate] Deve retornar a mesma lista quando o predicate for null.")]
        public void DeveFazerNadaQuandoPredicateForNulo()
        {
            var actual = IListMock.CreateIntList()
                                  .AsQueryable()
                                  .SetPredicate(null)
                                  .ToList();


            actual.Count.Should().Be(10);
        }

        [Fact(DisplayName = "[QueryableExtensions.SetPredicate] Deve filtrar as informações quando o predicate for informardo.")]
        public void DeveFiltrarDadosQuandoPredicateInformado()
        {
            var actual = IListMock.CreateIntList()
                                  .AsQueryable()
                                  .SetPredicate(val => val % 2 == 0)
                                  .ToList();


            actual.Count.Should().Be(5);
        }
    }
}