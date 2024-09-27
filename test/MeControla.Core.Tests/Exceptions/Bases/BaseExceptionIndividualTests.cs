using MeControla.Core.Exceptions;
using MeControla.Core.Tests.Mocks;
using MeControla.Core.Tests.Mocks.Primitives;
using System.Net;

namespace MeControla.Core.Tests.Exceptions.Bases;

public abstract class BaseExceptionIndividualTests<T>(HttpStatusCode statusCode, string messageDefault, string messageCustom) : BaseExceptionTests
    where T : HttpException, new()
{
    private readonly HttpStatusCode statusCode = statusCode;
    private readonly string messageDefault = messageDefault;
    private readonly string messageCustom = messageCustom;

    public virtual void DeveGerarExcecaoSemMensagem()
    {
        var exception = CreateInstance<T>();

        ShouldBe(exception, statusCode, messageDefault, null);
    }

    public virtual void DeveGerarExcecaoComMensagem()
    {
        var exception = CreateInstance<T>([DataMock.TEXT_EXCEPTION_MESSAGE]);

        ShouldBe(exception, statusCode, messageCustom, null);
    }

    public virtual void DeveGerarExcecaoComMensagemEInnerException()
    {
        var innerException = ExceptionMock.Create();
        var exception = CreateInstance<T>([DataMock.TEXT_EXCEPTION_MESSAGE, innerException]);

        ShouldBe(exception, statusCode, messageCustom, innerException);
    }
}