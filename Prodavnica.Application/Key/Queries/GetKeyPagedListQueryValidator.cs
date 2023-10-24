using FluentValidation;

namespace Prodavnica.Application.Key.Queries;

public class GetKeyPagedListQueryValidator : AbstractValidator<GetKeyPagedListQuery>
{
    public GetKeyPagedListQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.SearchQuery)
            .MinimumLength(3)
            .When(s => s != null);
    }
}