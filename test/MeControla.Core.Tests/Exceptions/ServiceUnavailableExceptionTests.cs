﻿using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Exceptions.Bases;
using MeControla.Core.Tests.Mocks;
using System.Net;
using Xunit;

namespace MeControla.Core.Tests.Exceptions;

public class ServiceUnavailableExceptionTests : BaseExceptionIndividualTests<ServiceUnavailableException>
{
    public ServiceUnavailableExceptionTests()
        : base(HttpStatusCode.ServiceUnavailable, ResourceThrowMessageDefault.ServiceUnavailable, DataMock.TEXT_EXCEPTION_MESSAGE)
    { }

    [Fact(DisplayName = "[ServiceUnavailableException.Constructor] Deve gerar exceção utilizando construtor padrão.")]
    public override void DeveGerarExcecaoSemMensagem()
        => base.DeveGerarExcecaoSemMensagem();

    [Fact(DisplayName = "[ServiceUnavailableException.Constructor] Deve gerar exceção com a mensagem definida.")]
    public override void DeveGerarExcecaoComMensagem()
        => base.DeveGerarExcecaoSemMensagem();

    [Fact(DisplayName = "[ServiceUnavailableException.Constructor] Deve gerar exceção com a mensagem e inner exception definidos.")]
    public override void DeveGerarExcecaoComMensagemEInnerException()
        => base.DeveGerarExcecaoComMensagemEInnerException();
}