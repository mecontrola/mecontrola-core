using FluentAssertions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Builders;
using Xunit;

namespace MeControla.Core.Tests.Builders
{
    public class BaseBuilderTests
    {
        [Fact(DisplayName = "[BaseBuilder.ToBuild] Deve criar um objeto do tipo criado e preenchido com as informações definidas.")]
        public void DeveCriarUserComCampoNomePreenchido()
        {
            var actual = UserBuilder.GetInstance()
                                    .SetName(DataMock.NAME_DEV_1)
                                    .ToBuild();

            actual.Uuid.Should().NotBeEmpty();
            actual.Name.Should().Be(DataMock.NAME_DEV_1);
        }
    }
}