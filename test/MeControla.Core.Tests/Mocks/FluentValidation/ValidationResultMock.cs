using FluentValidation.Results;

namespace MeControla.Core.Tests.Mocks.FluentValidation;

public class ValidationResultMock
{
    public static ValidationResult CreateEmpty()
        => new(ValidationFailureMock.CreateListEmpty());

    public static ValidationResult CreateFillUser()
      => new(ValidationFailureMock.ValidationFailure());
}