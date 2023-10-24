using AutoMapper;
using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Keys;

namespace Prodavnica.Application.Key.Queries;

public record GetKeyListQuery() : IRequest<KeyListDto>;

public class GetKeyListQueryHandler : IRequestHandler<GetKeyListQuery, KeyListDto>
{
    private readonly IMapper _mapper;

    public GetKeyListQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyListDto> Handle(GetKeyListQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<KeyListDto>(await DB.Find<Prodavnica.Domain.Entities.Key>()
            .ExecuteAsync(cancellationToken));
    }
}