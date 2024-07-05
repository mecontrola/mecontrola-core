using FluentAssertions;
using MeControla.Core.Exceptions;
using MeControla.Core.Extensions;
using MeControla.Core.Tests.Mocks.Datas.Entities;
using MeControla.Core.Tests.Mocks.Datas.InputDtos;
using MeControla.Core.Tests.Mocks.InputDtos;
using MeControla.Core.Tests.Mocks.Validators;
using System;
using Xunit;

namespace MeControla.Core.Tests.Extensions
{
    public class IValidatorExtensionsTests
    {
        [Fact(DisplayName = "[IValidatorExtensions.ThrowIfInvalid] Deve gerar exceção quando o IValidator for null.")]
        public void DeveGerarExcecaoQuandoValidatorNull()
        {
            var validator = (UserInputDtoValidator)null;

            var act = () => validator.ThrowIfInvalid<User, UserInputDto>(UserInputDtoMock.CreateUser1());
            act.Should().Throw<ArgumentNullException>();
            act.Should().NotThrow<FormValidationException>();
        }

        [Fact(DisplayName = "[IValidatorExtensions.ThrowIfInvalid] Deve gerar exceção quando o InputDto for inválido.")]
        public void DeveGerarExcecaoQuandoInputDtoInvalido()
        {
            var validator = new UserInputDtoValidator();

            var act = () => validator.ThrowIfInvalid<User, UserInputDto>(UserInputDtoMock.CreateEmpty());
            act.Should().NotThrow<ArgumentNullException>();
            act.Should().Throw<FormValidationException>();
        }

        [Fact(DisplayName = "[IValidatorExtensions.ThrowIfInvalid] Deve finalizar quando o IValidator validar InputDto e não gerar exceção.")]
        public void DeveFinalizarQuandoInputDtoValido()
        {
            var validator = new UserInputDtoValidator();

            var act = () => validator.ThrowIfInvalid<User, UserInputDto>(UserInputDtoMock.CreateUser1());
            act.Should().NotThrow<ArgumentNullException>();
            act.Should().NotThrow<FormValidationException>();
        }
    }
}