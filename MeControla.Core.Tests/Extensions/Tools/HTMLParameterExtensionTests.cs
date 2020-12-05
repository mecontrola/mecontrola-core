using MeControla.Core.Extensions.Tools;
using MeControla.Core.Tools.HtmlParse;
using Xunit;

namespace MeControla.Core.Tests.Extensions.Tools
{
    public class HTMLParameterExtensionTests
    {
        [Fact(DisplayName = "[HTMLParameterExtension.HasAttributeInTag] Deve retornar true quando objeto vazio e parâmetro nulo.")]
        public void DeveValidarQuandoMatchForNulo()
        {
            var parameters = new HTMLAttributes();

            Assert.True(parameters.HasAttributeInTag(null));
        }

        [Fact(DisplayName = "[HTMLParameterExtension.HasAttributeInTag] Deve retornar false quando objeto nulo e parâmetro vazio.")]
        public void DeveInvalidarQuandoObjetoForNulo()
        {
            var parameters = (HTMLAttributes)null;

            Assert.False(parameters.HasAttributeInTag(new HTMLAttributes()));
        }

        [Fact(DisplayName = "[HTMLParameterExtension.HasAttributeInTag] Deve retornar false quando atributos do parâmetro maior que o objeto.")]
        public void DeveInvalidarQuandoMatchTiverMaisAttributosDoQueAlvo()
        {
            var parameters = new HTMLAttributes { { "id", "id-test" }, { "class", "cls-test" } };
            var match = new HTMLAttributes { { "id", "id-test" }, { "class", "cls-test" }, { "data-tagert", "id-target" } };

            Assert.False(parameters.HasAttributeInTag(match));
        }

        [Fact(DisplayName = "[HTMLParameterExtension.HasAttributeInTag] Deve retornar true quando atributos do parâmetro menor que o objeto.")]
        public void DeveValidarQuandoMatchTiverTodosAttributosDoAlvo()
        {
            var parameters = new HTMLAttributes { { "id", "id-test" }, { "class", "cls-test" }, { "data-tagert", "id-target" } };
            var match = new HTMLAttributes { { "id", "id-test" }, { "class", "cls-test" } };

            Assert.True(parameters.HasAttributeInTag(match));
        }

        [Fact(DisplayName = "[HTMLParameterExtension.RemoveTagAndContent] Deve retornar tag html com o seu respectivo conteúdo.")]
        public void DeveRemoverTagHtmlDeTexto()
        {
            var expected = "Teste de HTML";
            var actual = "Teste de HTML <p>Tente a sorte</p>".RemoveTagAndContent();

            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "[HTMLParameterExtension.HtmlRemoveEncondeDecode] Deve retornar html encode da string.")]
        public void DeveRemoverHtmlEncondeDecode()
        {
            var expected = "Teste de HTML";
            var actual = "Teste&nbsp;de&nbsp;HTML&nbsp;".HtmlRemoveEncondeDecode();

            Assert.Equal(expected, actual);
        }
    }
}