using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Primitives;

public class ListMock
{
    public static List<string> CreateListUserError()
        => [
            DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_1,
            DataMock.TEXT_FORM_EXCEPTION_FIELD_ERROR_2
        ];
}