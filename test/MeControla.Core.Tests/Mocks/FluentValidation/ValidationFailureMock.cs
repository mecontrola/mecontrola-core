using FluentValidation.Results;
using MeControla.Core.Tests.Mocks.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace MeControla.Core.Tests.Mocks.FluentValidation;

public class ValidationFailureMock
{
    public static IList<ValidationFailure> CreateListEmpty()
        => [];

    public static IList<ValidationFailure> ValidationFailure()
        => DictionaryMock.CreateUserError()
                         .Select(itm => itm.Value.Select(value => new ValidationFailure(itm.Key, value)))
                         .SelectMany(itm => itm)
                         .ToList();
}