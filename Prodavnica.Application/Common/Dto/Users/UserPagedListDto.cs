namespace Prodavnica.Application.Common.Dto.Users;

public record UserPagedListDto(List<UserDto> Users, PaginationDto Pagination)
{
    internal UserPagedListDto AddPagination(PaginationDto paginationDto)
    {
        return this with { Pagination = paginationDto };
    }
}