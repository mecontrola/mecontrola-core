using FluentAssertions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact(DisplayName = "[StringExtensions.IsNullOrEmpty] Deve retornar true quando string for nula.")]
        public void DeveRetornarTrueQuandoNulo_Empty()
            => ((string)null).IsNullOrEmpty()
                             .Should()
                             .BeTrue();

        [Fact(DisplayName = "[StringExtensions.IsNullOrEmpty] Deve retornar true quando string for vazia.")]
        public void DeveRetornarTrueQuandoVazio_Empty()
            => "".IsNullOrEmpty()
                 .Should()
                 .BeTrue();

        [Fact(DisplayName = "[StringExtensions.IsNullOrEmpty] Deve retornar false quando string tiver espaço.")]
        public void DeveRetornarFalseQuandoEspaco_Empty()
            => " ".IsNullOrEmpty()
                  .Should()
                  .BeFalse();

        [Fact(DisplayName = "[StringExtensions.IsNullOrEmpty] Deve retornar false quando string tiver texto.")]
        public void DeveRetornarFalseQuandoTexto_Empty()
            => DataMock.VALUE_DEFAULT_TEXT
                       .IsNullOrEmpty()
                       .Should()
                       .BeFalse();

        [Fact(DisplayName = "[StringExtensions.IsNullOrWhiteSpace] Deve retornar true quando string for nula.")]
        public void DeveRetornarTrueQuandoNulo_WhiteSpace()
            => ((string)null).IsNullOrWhiteSpace()
                             .Should()
                             .BeTrue();

        [Fact(DisplayName = "[StringExtensions.IsNullOrWhiteSpace] Deve retornar true quando string for vazia.")]
        public void DeveRetornarTrueQuandoVazio_WhiteSpace()
            => "".IsNullOrWhiteSpace()
                 .Should()
                 .BeTrue();

        [Fact(DisplayName = "[StringExtensions.IsNullOrWhiteSpace] Deve retornar true quando string tiver espaço.")]
        public void DeveRetornarFalseQuandoEspaco_WhiteSpace()
            => " ".IsNullOrWhiteSpace()
                  .Should()
                  .BeTrue();

        [Fact(DisplayName = "[StringExtensions.IsNullOrWhiteSpace] Deve retornar false quando string tiver texto.")]
        public void DeveRetornarFalseQuandoTexto_WhiteSpace()
            => DataMock.VALUE_DEFAULT_TEXT
                       .IsNullOrWhiteSpace()
                       .Should()
                       .BeFalse();

        [Fact(DisplayName = "[StringExtensions.ToGuid] Deve converter um guid string em um guid objeto.")]
        public void DeveConverterGuidStringParaGuid()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString().ToGuid();

            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve convert uma data string em um DateTime.")]
        public void DeveConverterDateTimeStringParaDateTime()
        {
            var expected = new DateTime(2020, 1, 1);
            var actual = "2020-01-01".ToDateTime();

            actual.Should().Be(expected);
        }

        [Theory(DisplayName = "[StringExtensions.ToPascalCase] Deve retornar uma string formatada como pascal case.")]
        [InlineData("some_database_field_name", "SomeDatabaseFieldName")]
        [InlineData("Some label that needs to be title-cased", "SomeLabelThatNeedsToBeTitleCased")]
        [InlineData("some-package-name", "SomePackageName")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "SomeMixedStringWithSpacesUnderscoresAndHyphens")]
        public void DeveRetornarPascalCase(string actual, string expected)
            => actual.ToPascalCase()
                     .Should()
                     .Be(expected);

        [Theory(DisplayName = "[StringExtensions.ToCamelCase] Deve retornar uma string formatada como camel case.")]
        [InlineData("some_database_field_name", "someDatabaseFieldName")]
        [InlineData("Some label that needs to be title-cased", "someLabelThatNeedsToBeTitleCased")]
        [InlineData("some-package-name", "somePackageName")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "someMixedStringWithSpacesUnderscoresAndHyphens")]
        public void DeveRetornarCamelCase(string actual, string expected)
            => actual.ToCamelCase()
                     .Should()
                     .Be(expected);

        [Theory(DisplayName = "[StringExtensions.ToSnakeCase] Deve retornar uma string formatada como snake case.")]
        [InlineData("camelCase", "camel_case")]
        [InlineData("some text", "some_text")]
        [InlineData("some-mixed_string With spaces_underscores-and-hyphens", "some_mixed_string_with_spaces_underscores_and_hyphens")]
        [InlineData("AllThe-small Things", "all_the_small_things")]
        public void DeveRetornarSnakeCase(string actual, string expected)
            => actual.ToSnakeCase()
                     .Should()
                     .Be(expected);

        [Theory(DisplayName = "[StringExtensions.ToKebabCase] Deve retornar uma string formatada como kebab case.")]
        [InlineData("camelCase", "camel-case")]
        [InlineData("some text", "some-text")]
        [InlineData("some-mixed_string With spaces_underscores-and-hyphens", "some-mixed-string-with-spaces-underscores-and-hyphens")]
        [InlineData("AllThe-small Things", "all-the-small-things")]
        public void DeveRetornarKebabCase(string actual, string expected)
            => actual.ToKebabCase()
                     .Should()
                     .Be(expected);

        [Theory(DisplayName = "[StringExtensions.ToTitleCase] Deve retornar uma string formatada como title case.")]
        [InlineData("some_database_field_name", "Some Database Field Name")]
        [InlineData("Some label that needs to be title-cased", "Some Label That Needs To Be Title Cased")]
        [InlineData("some-package-name", "Some Package Name")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "Some Mixed String With Spaces Underscores And Hyphens")]
        public void DeveRetornarTitleCase(string actual, string expected)
            => actual.ToTitleCase()
                     .Should()
                     .Be(expected);

        [Fact(DisplayName = "[StringExtensions.OnlyNumbers] Deve retornar uma string contendo somente números.")]
        public void DeveManterSomenteNumerosString()
            => "as8df4sdf3asdf5534".OnlyNumbers()
                                   .Should()
                                   .Be("8435534");

        [Fact(DisplayName = "[StringExtensions.Base64Encode] Deve realizar a codificação em base64 de um texto.")]
        public void DeveRealizarEncodeTexto()
        {
            var actual = DataMock.TEXT_DECODE.Base64Encode();
            actual.Should().BeEquivalentTo(DataMock.TEXT_ENCODE);
        }

        [Fact(DisplayName = "[StringExtensions.Base64Encode] Deve gerar execeção quando o valor para codificação em base64 for null.")]
        public void DeveGerarExcecaoEncodeQuandoNull()
        {
            var act = () => ((string)null).Base64Encode();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "[StringExtensions.Base64Encode] Deve gerar execeção quando o valor para codificação em base64 for vazio.")]
        public void DeveGerarExcecaoEncodeQuandoVazio()
        {
            var act = () => string.Empty.Base64Encode();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "[StringExtensions.Base64Decode] Deve realizar a decodificação em base64 de um texto.")]
        public void DeveRealizarDecodeTexto()
        {
            var actual = DataMock.TEXT_ENCODE.Base64Decode();
            actual.Should().BeEquivalentTo(DataMock.TEXT_DECODE);
        }

        [Fact(DisplayName = "[StringExtensions.Base64Decode] Deve gerar execeção quando o valor para decodificação em base64 for null.")]
        public void DeveGerarExcecaoDecodeQuandoNull()
        {
            var act = () => ((string)null).Base64Decode();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "[StringExtensions.Base64Decode] Deve gerar execeção quando o valor para decodificação em base64 for vazio.")]
        public void DeveGerarExcecaoDecodeQuandoVazio()
        {
            var act = () => string.Empty.Base64Decode();
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact(DisplayName = "[StringExtensions.TrimAll] Deve remover o excesso de espaços em um texto.")]
        public void DeveRemoverExcessoEspacosTexto()
        {
            var actual = DataMock.TEXT_SPACES.TrimAll();
            actual.Should().BeEquivalentTo(DataMock.TEXT_DECODE);
        }

        [Fact(DisplayName = "[StringExtensions.ToMD5] Deve realizar a decodificação em MD5 de um texto.")]
        public void DeveRealizarEncodeMD5Texto()
        {
            var actual = DataMock.TEXT_ENCODE.ToMD5();
            actual.Should().BeEquivalentTo(DataMock.TEXT_ENCODE_MD5);
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor DateTime em string para um DateTime.")]
        public void DeveRealizarConversaoStringValidaParaDateTime()
        {
            var expected = (DateTime?)DataMock.DATETIME_QUARTER_2_2000;
            var actual = DataMock.TEXT_DATETIME.ToDateTime();

            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor string vazia para um DateTime nulo.")]
        public void DeveRealizarConversaoStringVaziaParaDateTimeNull()
        {
            var actual = string.Empty.ToNullableDateTime();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDateTime] Deve realizar conversão de uma valor decimal em string para um decimal.")]
        public void DeveRealizarConversaoStringValidaParaDecimal()
        {
            var expected = DataMock.DECIMAL_DEFAULT;
            var actual = DataMock.TEXT_DECIMAL.ToDecimal();

            actual.Should().Be(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal] Deve realizar conversão de uma valor string vazia para um decimal nulo.")]
        public void DeveRealizarConversaoStringVaziaParaDecimalNull()
        {
            var actual = string.Empty.ToDecimal();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal] Deve realizar conversão de uma valor string somente texto para um decimal nulo.")]
        public void DeveRealizarConversaoStringSomenteTextoParaDecimalNull()
        {
            var actual = DataMock.VALUE_DEFAULT_TEXT.ToDecimal();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToDecimal] Deve realizar conversão de uma valor maior que valor decimal para um decimal nulo.")]
        public void DeveRealizarConversaoOverflowParaDecimalNull()
        {
            var actual = $"{decimal.MaxValue}4".ToDecimal();

            actual.Should().BeNull();
        }

        [Fact(DisplayName = "[StringExtensions.ToFirstUpper] Deve alterar somente a primeira letra da string para upper case.")]
        public void DeveAlterarParaUpperCaseSomentePrimeiraLetra()
        {
            var expected = DataMock.VALUE_DEFAULT_TEXT;
            var actual = expected.ToLower()
                                 .Split(" ")
                                 .Select(x => x.ToFirstUpper());

            string.Join(" ", actual).Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "[StringExtensions.ToFirstUpper] Deve retornar vazio quando o valor passado for vazio.")]
        public void DeveRetornarVazioQuandoValorVazio()
        {
            var expected = string.Empty;
            var actual = expected.ToFirstUpper();

            actual.Should().BeEquivalentTo(expected);
        }
    }
}