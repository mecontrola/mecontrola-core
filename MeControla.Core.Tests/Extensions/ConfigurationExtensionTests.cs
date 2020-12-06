using MeControla.Core.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class ConfigurationExtensionTests
    {
        private const string CONFIG_VALUE_1 = "value1";
        private const string CONFIG_VALUE_2 = "value2";

        private readonly IConfiguration configuration;

        public ConfigurationExtensionTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { $"{nameof(TestConfig)}:{nameof(TestConfig.SomeKey)}" , CONFIG_VALUE_1 },
                { $"{nameof(TestConfig)}:{nameof(TestConfig.SomeOtherKey)}" , CONFIG_VALUE_2 }
            };

            configuration = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        }

        [Fact(DisplayName = "[Configuration.Load] Deve carrega objeto quando existir a configuração.")]
        public void DeveCarregaObjetoQuandoExistir()
        {
            var config = configuration.Load<TestConfig>();

            Assert.Equal(CONFIG_VALUE_1, config.SomeKey);
            Assert.Equal(CONFIG_VALUE_2, config.SomeOtherKey);
        }

        [Fact(DisplayName = "[Configuration.Load] Deve carrega null quando não existir a configuração.")]
        public void DeveCarregaNullQuandoNaoExistir()
        {
            var config = configuration.Load<TestConfigNotFound>();

            Assert.Null(config);
        }
    }

    class TestConfig
    {
        public string SomeKey { get; set; }
        public string SomeOtherKey { get; set; }
    }

    class TestConfigNotFound { }
}