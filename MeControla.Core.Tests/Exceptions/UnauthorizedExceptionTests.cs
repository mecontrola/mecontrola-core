using FluentAssertions;
using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Mocks;
using System;
using Xunit;

namespace MeControla.Core.Tests.Exceptions
{
    public sealed class UnauthorizedExceptionTests
    {
        [Fact(DisplayName = "[UnauthorizedException.Constructor] Deve gerar exceção com InnerException definido.")]
        public void Constructor_WithInnerException_ShouldSetInnerException()
        {
            var innerException = new Exception(DataMock.TEXT_EXCEPTION_MESSAGE);

            var exception = new UnauthorizedException(innerException);
            exception.InnerException.Should().BeEquivalentTo(innerException);
        }

        [Fact(DisplayName = "[UnauthorizedException.Constructor] Deve gerar exceção sem InnerException.")]
        public void DeveGerarExecaoSemInnerException()
        {
            var exception = new UnauthorizedException();
            exception.InnerException.Should().BeNull();
        }
    }
}