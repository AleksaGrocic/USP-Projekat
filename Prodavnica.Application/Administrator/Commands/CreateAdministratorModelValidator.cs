using FluentValidation;

namespace Prodavnica.Application.Administrator.Commands;

public class CreateAdministratorModelValidator : AbstractValidator<CreateAdministrator>
{
    public CreateAdministratorModelValidator()
    {
        RuleFor(x => x.EmailAddress).EmailAddress().NotNull();
    }
}