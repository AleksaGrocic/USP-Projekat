using AutoMapper;
using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto;
using Prodavnica.Application.Common.Dto.Keys;
using Prodavnica.Application.Extensions.Key;

namespace Prodavnica.Application.Key.Queries;

public record GetKeyPagedListQuery(int PageSize, int PageNumber, string? SearchQuery) : IRequest<KeyPagedListDto>;

public class GetKeyPagedQueryHandler : IRequestHandler<GetKeyPagedListQuery, KeyPagedListDto>
{
    private readonly IMapper _mapper;

    public GetKeyPagedQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyPagedListDto> Handle(GetKeyPagedListQuery request, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<Domain.Entities.Key>()
            .Sort(b => b.Name,
                Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);
        
        return _mapper.Map<KeyPagedListDto>(res.Results).AddPagination(new PaginationDto(res.TotalCount, res.PageCount));
    }
}