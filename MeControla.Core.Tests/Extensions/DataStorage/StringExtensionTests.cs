using MeControla.Core.Extensions.DataStorage;
using Xunit;

namespace MeControla.Core.Tests.Extensions.DataStorage
{
    public class StringExtensionTests
    {
        private const string PREFIX = "test";

        [Fact(DisplayName = "[StringExtension.GetColumnName] Deve converter a string em snake case e adicionar um prefixo.")]
        public void DeveMontarNomeCampoTabelaSnakeCase()
        {
            var expected = "test_campo_snake_case";
            var actual = "CampoSnakeCase".GetColumnName(PREFIX);

            Assert.Equal(expected, actual);
        }
    }
}