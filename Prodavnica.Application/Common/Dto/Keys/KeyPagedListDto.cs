namespace Prodavnica.Application.Common.Dto.Keys;

public record KeyPagedListDto(List<Task<KeyDetailsDto>> Key, PaginationDto Pagination)
{
    internal KeyPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { Pagination = paginationDto };
    }
}