using FluentAssertions;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using System;
using System.ComponentModel;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Extensions;

public class FieldInfoExtensionsTests
{
    [Fact(DisplayName = "[FieldInfoExtensions.GetCustomAttribute] Deve retornar o atributo customizado do campo.")]
    public void DeveRetornarAtributoCustomizadoDoCampo()
    {
        var fieldInfo = typeof(ClassTest).GetField(nameof(ClassTest.FieldInClass1));

        var result = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

        result.Should().NotBeNull();
        result.Description.Should().Be("TestValue");
    }

    [Fact(DisplayName = "[FieldInfoExtensions.GetCustomAttribute] Deve retornar nulo quando o campo não tiver o atributo.")]
    public void DeveRetornarNuloQuandoCampoNaoTiverAtributo()
    {
        var fieldInfo = typeof(ClassTest).GetField(nameof(ClassTest.FieldInClass2));

        var result = fieldInfo.GetCustomAttribute<DescriptionAttribute>();

        result.Should().BeNull();
    }

    [Fact(DisplayName = "[FieldInfoExtensions.GetCustomAttribute] Deve lançar exceção quando FieldInfo for nulo.")]
    public void DeveLancarExcecaoQuandoFieldInfoForNulo()
    {
        FieldInfo fieldInfo = null;

        var act = () => fieldInfo.GetCustomAttribute<DescriptionAttribute>();

        act.Should().Throw<ArgumentNullException>().WithMessage("*fieldInfo*");
    }

    [Fact(DisplayName = "[FieldInfoExtensions.GetCustomAttribute] Deve retornar nulo quando o atributo do tipo especificado não estiver presente.")]
    public void DeveRetornarNuloQuandoAtributoNaoEstiverPresente()
    {
        var fieldInfo = typeof(ClassTest).GetField(nameof(ClassTest.FieldInClass1));

        var result = fieldInfo.GetCustomAttribute<ObsoleteAttribute>();

        result.Should().BeNull();
    }
}
