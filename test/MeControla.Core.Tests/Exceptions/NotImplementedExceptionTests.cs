using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Exceptions.Bases;
using MeControla.Core.Tests.Mocks;
using System.Net;
using Xunit;

namespace MeControla.Core.Tests.Exceptions;

public class NotImplementedExceptionTests : BaseExceptionIndividualTests<NotImplementedException>
{
    public NotImplementedExceptionTests()
        : base(HttpStatusCode.NotImplemented, ResourceThrowMessageDefault.NotImplemented, DataMock.TEXT_EXCEPTION_MESSAGE)
    { }

    [Fact(DisplayName = "[NotImplementedException.Constructor] Deve gerar exceção utilizando construtor padrão.")]
    public override void DeveGerarExcecaoSemMensagem()
        => base.DeveGerarExcecaoSemMensagem();

    [Fact(DisplayName = "[NotImplementedException.Constructor] Deve gerar exceção com a mensagem definida.")]
    public override void DeveGerarExcecaoComMensagem()
        => base.DeveGerarExcecaoSemMensagem();

    [Fact(DisplayName = "[NotImplementedException.Constructor] Deve gerar exceção com a mensagem e inner exception definidos.")]
    public override void DeveGerarExcecaoComMensagemEInnerException()
        => base.DeveGerarExcecaoComMensagemEInnerException();
}