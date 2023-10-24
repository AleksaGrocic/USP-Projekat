using FluentValidation;


namespace Prodavnica.Application.Vendor.Commands;

public class UpdateVendorCommandValidator : AbstractValidator<UpdateVendorCommand>
{
    public UpdateVendorCommandValidator()
    {
        RuleFor(x => x.Vendor.name).MaximumLength(512).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Vendor.ActiveName).NotEmpty();
        /*RuleFor(x => x.User)
            .SetValidator(new UpdateUserDtoValidator());*/
    }
}