using FluentValidation;

namespace Prodavnica.Application.Category.Queries;

public class GetCategoryPagedListQueryValidator : AbstractValidator<GetCategoryPagedListQuery>
{
    public GetCategoryPagedListQueryValidator()
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