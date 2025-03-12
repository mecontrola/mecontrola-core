using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tests.Mocks.Entities;
using MeControla.Core.Tests.Mocks.Primitives;
using System;
using System.Linq;
using Xunit;

namespace MeControla.Core.Tests.Extensions;

public class QueryableExtensionsTests
{
    private readonly IQueryable<SoftUser> query = SoftUserMock.CreateQueryable();

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

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] - Filtra corretamente com operador eq")]
    public void ApplyFilters_ShouldFilterWithEqOperator()
    {
        var filters = "name[eq]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(1);
        result.First().Name.Should().Be("John");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] - Filtra corretamente com operador ne")]
    public void ApplyFilters_ShouldFilterWithNeOperator()
    {
        var filters = "name[ne]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(3);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] - Filtra corretamente com operador gt")]
    public void ApplyFilters_ShouldFilterWithGtOperator()
    {
        var filters = "age[gt]=30";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] - Filtra corretamente com operador gte")]
    public void ApplyFilters_ShouldFilterWithGteOperator()
    {
        var filters = "age[gte]=30";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(3);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtra corretamente com operador lt")]
    public void ApplyFilters_ShouldFilterWithLtOperator()
    {
        var filters = "age[lt]=30";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(1);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador lte")]
    public void ApplyFilters_ShouldFilterWithLteOperator()
    {
        var filters = "age[lte]=30";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador ct (contains)")]
    public void DeveFiltarOperadorContains()
    {
        var filters = "name[ct]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador nct (not contains)")]
    public void DeveFiltarOperadorNotContains()
    {
        var filters = "name[nct]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
        result.First().Name.Should().Be("Jane");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador sct (starts with)")]
    public void DeveFiltarOperadorStartsWith()
    {
        var filters = "name[sct]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
        result.First().Name.Should().Be("John");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador nsct (not starts with)")]
    public void DeveFiltarOperadorNotStartsWith()
    {
        var filters = "name[nsct]=John";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(2);
        result.First().Name.Should().Be("Jane");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador ect (not ends with)")]
    public void DeveFiltarOperadorEndsWith()
    {
        var filters = "name[ect]=ce";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(1);
        result.First().Name.Should().Be("Alice");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente com operador nect (not ends with)")]
    public void DeveFiltarOperadorNotEndsWith()
    {
        var filters = "name[nect]=ce";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(3);
        result.First().Name.Should().Be("John");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve filtar corretamente filtrando mais de um campo.")]
    public void DeveGerarExecaoQuandoMaisumFiltro()
    {
        var filters = "name[eq]=Johnathan,age[gt]=30";

        var result = query.SetFilterBy(filters);

        result.Should().HaveCount(1);
        result.First().Name.Should().Be("Johnathan");
        result.First().Age.Should().Be(35);
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve lançar exceção para operador inválido.")]
    public void DeveGerarExecaoQuandoOperadorInvalido()
    {
        var filters = "name[invalid]=John";

        var act = () => query.SetFilterBy(filters);

        act.Should().Throw<InvalidOperationException>().WithMessage("Unsupported filter operation: invalid.");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve lançar exceção para tipo de valor inválido.")]
    public void DeveGerarExecaoQuandoTipoValorInvalido()
    {
        var filters = "age[eq]=John";

        var act = () => query.SetFilterBy(filters);

        act.Should().Throw<InvalidOperationException>().WithMessage("Cannot convert value to type Int32.");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve lançar exceção para formato inválido.")]
    public void DeveGerarExecaoQuandoFormatoInvalido()
    {
        var filters = "name[eq]=";

        var act = () => query.SetFilterBy(filters);

        act.Should().Throw<ArgumentException>().WithMessage($"Invalid filter format: {filters}.");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetFilterBy] Deve lançar exceção para campo inválido.")]
    public void DeveGerarExecaoQuandoCampoInvalido()
    {
        var filters = "lastname[eq]=Travolta";

        var act = () => query.SetFilterBy(filters);

        act.Should().Throw<ArgumentException>().WithMessage("Property 'lastname' does not exist.");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetSortBy] Deve ordenar corretamente por propriedade ascendente.")]
    public void DeveOrdernarAscendente()
    {
        var sorting = "name";

        var result = query.SetSortBy(sorting);

        result.First().Name.Should().Be("Alice");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetSortBy] Deve ordenar corretamente por propriedade descendente.")]
    public void DeveOrdernarDescendente()
    {
        var sorting = "name_desc";

        var result = query.SetSortBy(sorting);

        result.First().Name.Should().Be("Johnathan");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetSortBy] Deve ordenar corretamente por múltiplas propriedades.")]
    public void DeveOrdernarPorMultiplosCampos()
    {
        var sorting = "name_desc,age";

        var result = query.SetSortBy(sorting);

        result.First().Name.Should().Be("Johnathan");
        result.Last().Name.Should().Be("Alice");
    }

    [Fact(DisplayName = "[QueryableExtensions.SetSortBy] Deve retornar sem erro quando a lista de sorting é nula ou vazia.")]
    public void DeveRetornarQuandoNullOuEmpty()
    {
        var sorting = (string)null;

        var result = query.SetSortBy(sorting);

        result.Should().BeEquivalentTo(query);

        sorting = string.Empty;
        result = query.SetSortBy(sorting);

        result.Should().BeEquivalentTo(query);
    }
}