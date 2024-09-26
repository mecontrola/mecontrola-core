using MeControla.Core.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace MeControla.Core.Tests.Exceptions.Bases;

public abstract class BaseExceptionHelperTests : BaseExceptionTests
{
    protected static void ExecuteAndValidateTests<T>(string methodName, ThrowHelperArgument args)
        where T : HttpException
    {
        var parameters = args.ToParameter();
        var types = parameters.Where(itm => itm != null)
                              .Select(itm => itm.GetType())
                              .ToArray();

        var type = typeof(ThrowHelper);
        var methodInfo = type.GetMethod(methodName, types);
        var instance = Assert.Throws<TargetInvocationException>(() => methodInfo.Invoke(null, parameters));

        ShouldBe((T)instance.InnerException, args.StatusCode, args.Message ?? args.MessageExpected, args.InnerException);
    }

    protected static TheoryData<ThrowHelperArgument> CreateParamExceptionTests(HttpStatusCode statusCode,
                                                                               string messageDefault,
                                                                               string messageCustom,
                                                                               Exception innerException)
        => new(
            new ThrowHelperArgument(statusCode, null, messageDefault, null),
            new ThrowHelperArgument(statusCode, messageDefault, messageDefault, null),
            new ThrowHelperArgument(statusCode, messageCustom, messageCustom, innerException)
        );

    public class ThrowHelperArgument(HttpStatusCode statusCode,
                                     string message,
                                     string messageExpected,
                                     Exception innerException)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
        public string Message { get; } = message;
        public string MessageExpected { get; } = messageExpected;
        public Exception InnerException { get; } = innerException;

        public object[] ToParameter()
            => new object[] { Message, InnerException }
                .Where(itm => itm != null)
                .ToArray();
    }
}