using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Configurations;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class ConfigurationExtensionTests
    {
        private const string FILENAME_APPSETTINGS_CUSTOM = "test_appsettings.json";
        private const string FILENAME_APPSETTINGS_DEFAULT = "appsettings.json";

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

        [Fact(DisplayName = "[IConfiguration.Load] Deve carrega objeto quando existir a configuração.")]
        public void DeveCarregaObjetoQuandoExistir()
        {
            var config = configuration.Load<TestConfig>();

            config.SomeKey.Should().Be(DataMock.CONFIG_VALUE_1);
            config.SomeOtherKey.Should().Be(DataMock.CONFIG_VALUE_2);
        }

        [Fact(DisplayName = "[IConfiguration.Load] Deve carrega null quando não existir a configuração.")]
        public void DeveCarregaNullQuandoNaoExistir()
        {
            var config = configuration.Load<TestConfigNotFound>();

            config.Should().BeNull();
        }

        [Fact(DisplayName = "[IConfiguration.SetValue] Deve salvar a alteração da configuração no arquivo appsettings quando não informado o caminho do arquivo.")]
        public void DeveSalvarAlteracaoArquivoAppSettingsQuandoNaoInformadoCaminho()
        {
            var pathname = CreateConfigurationMassData(FILENAME_APPSETTINGS_DEFAULT);

            var configuration = Substitute.For<IConfiguration>();
            configuration.SetValue("Logging:LogLevel:Default", "Information");
            configuration.SetValue("NewSection:NewKey", "NewValue");

            AssertionConfigurationSetValue(pathname);
        }

        [Fact(DisplayName = "[IConfiguration.SetValue] Deve salvar a alteração da configuração no arquivo appsettings quando informado o caminho do arquivo.")]
        public void DeveSalvarAlteracaoArquivoAppSettingsQuandoInformadoCaminho()
        {
            var pathname = CreateConfigurationMassData(FILENAME_APPSETTINGS_CUSTOM);

            var configuration = Substitute.For<IConfiguration>();
            configuration.SetValue("Logging:LogLevel:Default", "Information", FILENAME_APPSETTINGS_CUSTOM);
            configuration.SetValue("NewSection:NewKey", "NewValue", FILENAME_APPSETTINGS_CUSTOM);

            AssertionConfigurationSetValue(pathname);
        }

        private static string CreateConfigurationMassData(string filename)
        {
            var pathname = Path.Combine(AppContext.BaseDirectory, filename);

            File.WriteAllText(pathname, DefaultJsonText());

            return pathname;
        }

        private static void AssertionConfigurationSetValue(string pathname)
        {
            var updatedJson = File.ReadAllText(pathname);
            var jsonObj = JsonNode.Parse(updatedJson);

            jsonObj["Logging"]["LogLevel"]["Default"].ToString().Should().Be("Information");
            jsonObj["NewSection"]["NewKey"].ToString().Should().Be("NewValue");

            File.Delete(pathname);
        }

        private static string DefaultJsonText()
            => @"{
                ""Logging"": {
                    ""LogLevel"": {
                        ""Default"": ""Warning""
                    }
                }
            }";
    }
}