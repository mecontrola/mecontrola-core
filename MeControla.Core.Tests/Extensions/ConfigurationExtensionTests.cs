using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Configurations;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class ConfigurationExtensionTests
    {
        private readonly IConfiguration configuration;

        public ConfigurationExtensionTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { $"{nameof(TestConfig)}:{nameof(TestConfig.SomeKey)}" , DataMock.CONFIG_VALUE_1 },
                { $"{nameof(TestConfig)}:{nameof(TestConfig.SomeOtherKey)}" , DataMock.CONFIG_VALUE_2 }
            };

            configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        }

        [Fact(DisplayName = "[Configuration.Load] Deve carrega objeto quando existir a configuração.")]
        public void DeveCarregaObjetoQuandoExistir()
        {
            var config = configuration.Load<TestConfig>();

            config.SomeKey.Should().Be(DataMock.CONFIG_VALUE_1);
            config.SomeOtherKey.Should().Be(DataMock.CONFIG_VALUE_2);
        }

        [Fact(DisplayName = "[Configuration.Load] Deve carrega null quando não existir a configuração.")]
        public void DeveCarregaNullQuandoNaoExistir()
        {
            var config = configuration.Load<TestConfigNotFound>();

            config.Should().BeNull();
        }
    }
}