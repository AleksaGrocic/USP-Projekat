using AutoMapper;
using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto;
using Prodavnica.Application.Common.Dto.Category;
using Prodavnica.Application.Extensions.Category;

namespace Prodavnica.Application.Category.Queries;

public record GetCategoryPagedListQuery(int PageSize, int PageNumber, string? SearchQuery) : IRequest<CategoryPagedListDto>;

public class GetCategoryPagedQueryHandler : IRequestHandler<GetCategoryPagedListQuery, CategoryPagedListDto>
{
    private readonly IMapper _mapper;

    public GetCategoryPagedQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CategoryPagedListDto> Handle(GetCategoryPagedListQuery request, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<Prodavnica.Domain.Entities.Category>()
            .Sort(b => b.Name,
                Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        
        return _mapper.Map<CategoryPagedListDto>(res.Results).AddPagination(new PaginationDto(res.TotalCount, res.PageCount));
    }
}