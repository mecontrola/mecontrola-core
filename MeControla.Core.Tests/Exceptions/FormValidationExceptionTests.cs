using FluentAssertions;
using FluentValidation.Results;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;
using Xunit;

namespace MeControla.Core.Tests.Exceptions
{
    public sealed class FormValidationExceptionTests
    {
        [Fact(DisplayName = "[FormValidationException.Constructor] Deve gerar exceção com mensagem e listando os campos com os repectivos erros.")]
        public void DeveGerarExcecaoComListaCampos()
        {
            var expectedPropertyErrors = new Dictionary<string, List<string>>
            {
                { nameof(User.Name), new List<string> { DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_1, DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_2 } }
            };

            var exception = new FormValidationException(typeof(User), new ValidationResult([
                new ValidationFailure(nameof(User.Name), DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_1),
                new ValidationFailure(nameof(User.Name), DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_2)
            ]));

            exception.Message.Should().Be(DataMock.TEXT_FORM_EXCEPTION_MESSAGE);
            exception.PropertyErrors.Should().BeEquivalentTo(expectedPropertyErrors);
        }

        [Fact(DisplayName = "[FormValidationException.Constructor] Deve gerar exceção com mensagem sem a lista de campos com erros.")]
        public void DeveGerarExcecaoSemListaCampos()
        {
            var exception = new FormValidationException(typeof(User), new ValidationResult(new List<ValidationFailure>()));

            exception.Message.Should().Be(DataMock.TEXT_FORM_EXCEPTION_MESSAGE);
            exception.PropertyErrors.Should().BeEmpty();
        }
    }
}