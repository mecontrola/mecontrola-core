using MeControla.Core.Extensions;
using System;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class StringExtensionTests
    {
        [Fact(DisplayName = "[StringExtension.ToGuid] Deve converter um guid string em um guid objeto.")]
        public void DeveConverterGuidStringParaGuid()
        {
            var expected = Guid.NewGuid();
            var actual = expected.ToString().ToGuid();

            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "[StringExtension.ToDateTime] Deve convert uma data string em um DateTime.")]
        public void DeveConverterDateTimeStringParaDateTime()
        {
            var expected = new DateTime(2020, 1, 1);
            var actual = "2020-01-01".ToDateTime();

            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "[StringExtension.ToPascalCase] Deve retornar uma string formatada como pascal case.")]
        [InlineData("some_database_field_name", "SomeDatabaseFieldName")]
        [InlineData("Some label that needs to be title-cased", "SomeLabelThatNeedsToBeTitleCased")]
        [InlineData("some-package-name", "SomePackageName")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "SomeMixedStringWithSpacesUnderscoresAndHyphens")]
        public void DeveRetornarPascalCase(string actual, string expected)
        {
            Assert.Equal(expected, actual.ToPascalCase());
        }

        [Theory(DisplayName = "[StringExtension.ToCamelCase] Deve retornar uma string formatada como camel case.")]
        [InlineData("some_database_field_name", "someDatabaseFieldName")]
        [InlineData("Some label that needs to be title-cased", "someLabelThatNeedsToBeTitleCased")]
        [InlineData("some-package-name", "somePackageName")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "someMixedStringWithSpacesUnderscoresAndHyphens")]
        public void DeveRetornarCamelCase(string actual, string expected)
        {
            Assert.Equal(expected, actual.ToCamelCase());
        }

        [Theory(DisplayName = "[StringExtension.ToSnakeCase] Deve retornar uma string formatada como snake case.")]
        [InlineData("camelCase", "camel_case")]
        [InlineData("some text", "some_text")]
        [InlineData("some-mixed_string With spaces_underscores-and-hyphens", "some_mixed_string_with_spaces_underscores_and_hyphens")]
        [InlineData("AllThe-small Things", "all_the_small_things")]
        public void DeveRetornarSnakeCase(string actual, string expected)
        {
            Assert.Equal(expected, actual.ToSnakeCase());
        }

        [Theory(DisplayName = "[StringExtension.ToKebabCase] Deve retornar uma string formatada como kebab case.")]
        [InlineData("camelCase", "camel-case")]
        [InlineData("some text", "some-text")]
        [InlineData("some-mixed_string With spaces_underscores-and-hyphens", "some-mixed-string-with-spaces-underscores-and-hyphens")]
        [InlineData("AllThe-small Things", "all-the-small-things")]
        public void DeveRetornarKebabCase(string actual, string expected)
        {
            Assert.Equal(expected, actual.ToKebabCase());
        }

        [Theory(DisplayName = "[StringExtension.ToTitleCase] Deve retornar uma string formatada como title case.")]
        [InlineData("some_database_field_name", "Some Database Field Name")]
        [InlineData("Some label that needs to be title-cased", "Some Label That Needs To Be Title Cased")]
        [InlineData("some-package-name", "Some Package Name")]
        [InlineData("some-mixed_string with spaces_underscores-and-hyphens", "Some Mixed String With Spaces Underscores And Hyphens")]
        public void DeveRetornarTitleCase(string actual, string expected)
        {
            Assert.Equal(expected, actual.ToTitleCase());
        }

        [Fact]
        public void DeveManterSomenteNumerosString()
        {
            var expected = "8435534";
            var actual = "as8df4sdf3asdf5534".OnlyNumbers();

            Assert.Equal(expected, actual);
        }
    }
}