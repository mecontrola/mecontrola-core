using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks.Primitives;
using Xunit;

namespace MeControla.Core.Tests.Extensions;

public class CollectionExtensionsTests
{
    [Fact(DisplayName = "[CollectionExtensions.AddList] Deve adicionar os dados do enumerable quando a collection estiver vazia.")]
    public void DevePreencherCollectionQuandoEstiverVazia()
    {
        var expected = ICollectionMock.CreateFill2();
        var actual = ICollectionMock.CreateEmpty();

        actual.AddList(IEnumerableMock.CreateFill());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[CollectionExtensions.AddList] Deve adicionar os dados do enumerable quando a collection estiver preenchida.")]
    public void DevePreencherCollectionQuandoEstiverPreenchida()
    {
        var expected = ICollectionMock.CreateFill3();
        var actual = ICollectionMock.CreateFill();

        actual.AddList(IEnumerableMock.CreateFill());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[CollectionExtensions.SetList] Deve limpar e preencher collection com os dados de enumerable quando a collection estiver vazia.")]
    public void DeveLimparEPreencherCollectionQuandoEstiverVazia()
    {
        var expected = ICollectionMock.CreateFill2();
        var actual = ICollectionMock.CreateEmpty();

        actual.SetList(IEnumerableMock.CreateFill());

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[CollectionExtensions.SetList] Deve limpar e preencher collection com os dados de enumerable quando a collection estiver preenchida.")]
    public void DeveLimparEPreencherCollectionQuandoEstiverPreenchida()
    {
        var expected = ICollectionMock.CreateFill2();
        var actual = ICollectionMock.CreateEmpty();

        actual.SetList(IEnumerableMock.CreateFill());

        actual.Should().BeEquivalentTo(expected);
    }
}