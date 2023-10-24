namespace Prodavnica.Application.Common.Dto.Category;

public record CategoryPagedListDto(List<CategoryDto> Category, PaginationDto Pagination)
{
    internal CategoryPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { Pagination = paginationDto };
    }
}