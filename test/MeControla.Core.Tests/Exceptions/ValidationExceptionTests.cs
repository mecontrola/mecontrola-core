using FluentAssertions;
using FluentValidation.Results;
using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tests.Mocks.FluentValidation;
using MeControla.Core.Tests.Mocks.Primitives;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace MeControla.Core.Tests.Exceptions;

public class ValidationExceptionTests
{
    [Fact(DisplayName = "[ValidationException.Constructor] Deve gerar exceção com mensagem e listando os campos com os repectivos erros.")]
    public void DeveGerarExcecaoComListaCampos()
    {
        var expectedPropertyErrors = DictionaryMock.CreateUserError();

        var exception = new ValidationException(typeof(User), ValidationResultMock.CreateFillUser());

        ShouldBe(exception, expectedPropertyErrors, DataMock.TEXT_FORM_EXCEPTION_MESSAGE, null);
    }

    [Fact(DisplayName = "[ValidationException.Constructor] Deve gerar exceção com mensagem sem a lista de campos com erros.")]
    public void DeveGerarExcecaoSemListaCampos()
    {
        var exception = new ValidationException(typeof(User), ValidationResultMock.CreateEmpty());

        ShouldBe(exception, [], DataMock.TEXT_FORM_EXCEPTION_MESSAGE, null);
    }

    [Fact(DisplayName = "[ValidationException<T>.Constructor] Deve gerar exceção com mensagem e listando os campos com os repectivos erros.")]
    public void DeveGerarExcecaoTipoGenericoComListaCampos()
    {
        var expectedPropertyErrors = DictionaryMock.CreateUserError();

        var exception = new ValidationException<User>(ValidationResultMock.CreateFillUser());

        ShouldBe(exception, expectedPropertyErrors, DataMock.TEXT_FORM_EXCEPTION_MESSAGE, null);
    }

    [Fact(DisplayName = "[ValidationException<T>.Constructor] Deve gerar exceção com mensagem sem a lista de campos com erros.")]
    public void DeveGerarExcecaoTipoGenericoSemListaCampos()
    {
        var exception = new ValidationException<User>(ValidationResultMock.CreateEmpty());

        ShouldBe(exception, [], DataMock.TEXT_FORM_EXCEPTION_MESSAGE, null);
    }

    protected static void ShouldBe(ValidationException exception, Dictionary<string, List<string>> propertyErrors, string message, Exception innerException)
    {
        exception.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
        exception.PropertyErrors.Should().BeEquivalentTo(propertyErrors);
    }
}