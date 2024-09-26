using FluentAssertions;
using MeControla.Core.Extensions.JsonSerializers;
using System;
using System.Text.Json;
using Xunit;

namespace MeControla.Core.Tests.Extensions.JsonSerializers;

public class JsonSerializerAnonymousExtensionTests
{
    private const string DATE_FORMAT = "yyyyMMddHHmmss";

    [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve gerar execção quando a string for null.")]
    public void DeveGerarExcepcaoQuandoStringNull()
    {
        var act = () => ((string)null).ToAnonymousType<ClsTest>();

        act.Should().Throw<ArgumentNullException>().WithMessage($"{JsonSerializerAnonymousExtension.EXCEPTION_ARGUMENT_SOURCE_MESSAGE} (Parameter 'source')");
    }

    [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve gerar execção quando a string for vazia.")]
    public void DeveGerarExcepcaoQuandoStringVazia()
    {
        var act = () => string.Empty.ToAnonymousType<ClsTest>();

        act.Should().Throw<ArgumentNullException>().WithMessage($"{JsonSerializerAnonymousExtension.EXCEPTION_ARGUMENT_SOURCE_MESSAGE} (Parameter 'source')");
    }

    [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve gerar execção quando a string estiver com formato inválido.")]
    public void DeveGerarExcepcaoQuandoStringFormatoInvalido()
    {
        var act = () => "-".ToAnonymousType<ClsTest>();

        act.Should().Throw<JsonException>().WithMessage(JsonSerializerAnonymousExtension.EXCEPTION_DESERIALIZING_MESSAGE);
    }

    [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve converter um objeto anônimo para um tipado.")]
    public void DeveConverterObjetoAnonimoParaConcreto()
    {
        var expected = new ClsTest { Name = "Test" };
        var actual = $@"{{""Name"":""Test""}}".ToAnonymousType<ClsTest>();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact(DisplayName = "[JObjectExtension.ToAnonymousType] Deve converter um objeto anônimo para um tipado utilizando JsonSerializer.")]
    public void DeveConverterObjetoComDataOutroFormatoAnonimoParaConcreto()
    {
        var date = new DateTime(2020, 1, 1);
        var expected = new ClsTest { Name = "Test", Date = date };
        var actual = $@"{{""Name"":""Test"",""Date"":""{date.ToString(DATE_FORMAT)}""}}".ToAnonymousType<ClsTest>(GetTradingDaySerializer());

        actual.Should().BeEquivalentTo(expected);
    }

    private static JsonSerializerOptions GetTradingDaySerializer()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new DateTimeConverter(DATE_FORMAT));

        return options;
    }

    class ClsTest
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}