using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Primitives;
using System;
using System.Collections;
using System.Linq;
using Xunit;

namespace MeControla.Core.Tests.Extends.System.Linq;

public class PaginationTests
{
    [Fact(DisplayName = "[IEnumerable<T>.PagiantionBy] Deve gerar uma exceção quando a lista informada for nula.")]
    public void DeveGerarExcecaoQuandoListaNull()
    {
        var pagination = PaginationMock.CreatePage1();
        var source = IEnumerableMock.CreateNull();

        Assert.Throws<ArgumentNullException>(() => source.PaginationBy(pagination, DataMock.INT_PAGINATION_TOTAL));
    }

    [Fact(DisplayName = "[IEnumerable<T>.PagiantionBy] Deve gerar uma exceção quando as informações de paginação for nula.")]
    public void DeveGerarExcecaoQuandoPaginacaoNull()
    {
        var pagination = PaginationMock.CreateNull();
        var source = IEnumerableMock.CreateFill();

        Assert.Throws<ArgumentNullException>(() => source.PaginationBy(pagination, DataMock.INT_PAGINATION_TOTAL));
    }

    [Fact(DisplayName = "[IEnumerable<T>.PagiantionBy] Deve gerar o objeto de paginação quando nenhuma exceção for disparada.")]
    public void DeveGerarExcecaoQuandoCerto()
    {
        var pagination = PaginationMock.CreateLast();
        var source = IEnumerableMock.CreateFill();

        var actual = source.PaginationBy(pagination, DataMock.INT_PAGINATION_TOTAL);

        actual.Page.Should().Be(pagination.Page);
        actual.Limit.Should().Be(pagination.Limit);
        actual.Total.Should().Be(DataMock.INT_PAGINATION_TOTAL);
        actual.Should().BeEquivalentTo(source);

        var actualEnumerable = ((IEnumerable)actual).GetEnumerator();

        actualEnumerable.Should().NotBeNull();
        actualEnumerable.MoveNext().Should().BeTrue();
        actualEnumerable.Current.Should().Be(source.First());
    }
}