using FluentAssertions;
using MeControla.Core.Exceptions;
using System;
using System.Net;

namespace MeControla.Core.Tests.Exceptions.Bases;

public abstract class BaseExceptionTests
{
    protected static T CreateInstance<T>(params object[] args)
        where T : class
        => (T)Activator.CreateInstance(typeof(T), args);

    protected static void ShouldBe(HttpException exception, HttpStatusCode statusCode, string message, Exception innerException)
    {
        exception.StatusCode.Should().Be(statusCode);
        exception.Message.Should().Be(message);
        exception.InnerException.Should().Be(innerException);
    }
}