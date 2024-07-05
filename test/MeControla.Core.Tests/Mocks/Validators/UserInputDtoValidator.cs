using FluentValidation;
using MeControla.Core.Tests.Mocks.Datas.InputDtos;

namespace MeControla.Core.Tests.Mocks.Validators
{
    public class UserInputDtoValidator : AbstractValidator<UserInputDto>, IValidator<UserInputDto>
    {
        public const string FIELD_NAME_REQUIRED = "Name is required.";
        public const string FIELD_NAME_BETWEENLENGTH = "Name should be between 5 and 100 chars";

        public UserInputDtoValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop)
                                .NotEmpty()
                                .WithMessage(FIELD_NAME_REQUIRED)
                                .Must(x => x.Length > 5 && x.Length < 100)
                                .WithMessage(FIELD_NAME_BETWEENLENGTH);
        }
    }
}