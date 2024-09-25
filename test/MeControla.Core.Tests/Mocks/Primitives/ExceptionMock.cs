using System;

namespace MeControla.Core.Tests.Mocks.Primitives;

public class ExceptionMock
{
    public static Exception Create()
        => new(DataMock.TEXT_EXCEPTION_MESSAGE);
}