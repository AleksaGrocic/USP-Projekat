using FluentValidation;
using Prodavnica.Application.Common.Dto.Users;

namespace Prodavnica.Application.Common.Validators.Users;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(512)
            .NotEmpty()
            .MinimumLength(3);
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Wallet)
            .NotEmpty();
    }
}