using MeControla.Core.Tests.Mocks.Datas.Entities;
using System.Collections.Generic;

namespace MeControla.Core.Tests.Mocks.Primitives;

public class DictionaryMock
{
    public static Dictionary<string, List<string>> CreateUserError()
        => new()
        {
            { nameof(User.Name), ListMock.CreateListUserError() }
        };
}