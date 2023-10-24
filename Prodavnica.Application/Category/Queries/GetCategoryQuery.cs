using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Category;

namespace Prodavnica.Application.Category.Queries;

public record GetCategoryQuery(string CategoryId) : IRequest<CategoryDto>;
public class GetCategoryQueryHandler: IRequestHandler<GetCategoryQuery,CategoryDto>
{
    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await DB.Find<Domain.Entities.Category>().OneAsync(request.CategoryId, cancellationToken);
        if (category ==null)
        {
            throw new Exception("Vendor doesn't exist");
        }


        return new CategoryDto(category.Name);
    }
}
