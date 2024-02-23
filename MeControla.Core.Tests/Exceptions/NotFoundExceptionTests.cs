using FluentAssertions;
using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Mocks;
using Xunit;

namespace MeControla.Core.Tests.Exceptions
{
    public sealed class NotFoundExceptionTests
    {
        [Fact(DisplayName = "[NotFoundException.Constructor] Deve gerar exceção com a mensagem definida.")]
        public void DeveGerarExcecaoComMensagem()
        {
            var exception = new NotFoundException(DataMock.TEXT_EXCEPTION_MESSAGE);
            exception.Message.Should().Be(DataMock.TEXT_EXCEPTION_MESSAGE);
        }

        [Fact(DisplayName = "[NotFoundException.Constructor] Deve gerar exceção sem mensagem.")]
        public void DeveGerarExcecaoSemMensagem()
        {
            var exception = new NotFoundException();
            exception.Message.Should().BeEmpty();
        }
    }
}