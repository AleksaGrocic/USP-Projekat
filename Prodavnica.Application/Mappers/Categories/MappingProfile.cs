using AutoMapper;
using Prodavnica.Application.Common.Dto;
using Prodavnica.Application.Common.Dto.Category;

namespace Prodavnica.Application.Mappers.Categories;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<IEnumerable<Prodavnica.Domain.Entities.Category>, CategoryPagedListDto>()
            .ConstructUsing(x => ToCategoryPagedList(x));
    }

    private static CategoryDto GetCategoryDetails(Prodavnica.Domain.Entities.Category category)
    {
        return new CategoryDto(category.Name);
    }

    private static CategoryPagedListDto ToCategoryPagedList(IEnumerable<Prodavnica.Domain.Entities.Category> categories)
    {
        var categoryDtos = categories.Select(GetCategoryDetails).ToList();
        
        return new CategoryPagedListDto(categoryDtos,
            new PaginationDto(0,
                0));
    }
}