using FluentAssertions;
using MeControla.Core.Extensions.DataStorage;
using Xunit;

namespace MeControla.Core.Tests.Extensions.DataStorage;

public class StringExtensionTests
{
    private const string PREFIX = "test";

    [Fact(DisplayName = "[StringExtension.GetColumnName] Deve converter a string em snake case e adicionar um prefixo.")]
    public void DeveMontarNomeCampoTabelaSnakeCase()
    {
        var expected = "test_campo_snake_case";
        var actual = "CampoSnakeCase".GetColumnName(PREFIX);

        actual.Should().Be(expected);
    }

    [Theory(DisplayName = "[StringExtensions.GetPrefixColumn] Deve retornar uma string contendo de 3 a 4 caracteres das letras com os principais caracteres.")]
    [InlineData("ClassOfService", "cos")]
    [InlineData("CustomField", "csfl")]
    [InlineData("Holiday", "hld")]
    [InlineData("IssueCustomFieldData", "icfd")]
    [InlineData("IssueEpic", "isep")]
    [InlineData("IssueExtraData", "ied")]
    [InlineData("IssueImpediment", "isim")]
    [InlineData("Issue", "iss")]
    [InlineData("IssueStatusHistory", "ish")]
    [InlineData("IssueType", "isty")]
    [InlineData("Period", "prd")]
    [InlineData("PreferenceClassOfService", "pcos")]
    [InlineData("PreferenceCustomField", "pcf")]
    [InlineData("PreferenceIssueType", "pit")]
    [InlineData("PreferenceStatusCategory", "psc")]
    [InlineData("PreferenceStatus", "prst")]
    [InlineData("ProjectCategory", "prct")]
    [InlineData("Project", "prj")]
    [InlineData("StatusCategory", "stct")]
    [InlineData("Status", "stt")]
    public void DeveRetornarPreficoColuna(string actual, string expected)
        => actual.GetPrefixColumn()
                 .Should()
                 .Be(expected);

    [Theory(DisplayName = "[StringExtensions.GetPrefixTable] Deve retornar uma string contendo de 3 a 4 caracteres das letras com os principais caracteres.")]
    [InlineData("agile_manager", "am")]
    [InlineData("custom_manager", "cm")]
    [InlineData("manager", "mn")]
    [InlineData("agile", "ag")]
    public void DeveRetornarPreficoTabela(string actual, string expected)
        => actual.GetPrefixTable()
                 .Should()
                 .Be(expected);
}