using FluentValidation;

namespace Prodavnica.Application.Seller.Commands;

public class CreateSellerModelValidator : AbstractValidator<CreateSeller>
{
    public CreateSellerModelValidator()
    {
        RuleFor(x => x.EmailAddress).EmailAddress().NotNull();
    }
}