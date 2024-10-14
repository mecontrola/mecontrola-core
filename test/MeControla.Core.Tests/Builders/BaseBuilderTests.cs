using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Builders;
using System;
using Xunit;

namespace MeControla.Core.Tests.Builders;

public class BaseBuilderTests
{
    [Fact(DisplayName = "[BaseBuilder.ToBuild] Deve criar exceção ao criar uma instancia com new.")]
    public void DeveGerarExcecaoQuandoCriaInstanciaComNew()
    {
        var exception = () => new UserBuilder();
    
        exception.Should().ThrowExactly<InvalidOperationException>().WithMessage(UserBuilder.ERRO_CREATE_INSTANCE_NEW);
    }

    [Fact(DisplayName = "[BaseBuilder.ToBuild] Deve criar um objeto do tipo criado e preenchido com as informações definidas.")]
    public void DeveCriarUserComCampoNomePreenchido()
    {
        var actual = UserBuilder.GetInstance()
                                .SetName(DataMock.TEXT_USER_NAME_1)
                                .ToBuild();

        actual.Uuid.Should().NotBeEmpty();
        actual.Name.Should().Be(DataMock.TEXT_USER_NAME_1);
    }
}