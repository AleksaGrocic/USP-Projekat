using AutoMapper;
using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Keys;

namespace Prodavnica.Application.Key.Queries;

public record GetOneKeyQuery(string KeyId) : IRequest<KeyDetailsDto>;

public class GetOneKeyQueryHandler : IRequestHandler<GetOneKeyQuery, KeyDetailsDto>
{
    private readonly IMapper _mapper;

    public GetOneKeyQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<KeyDetailsDto> Handle(GetOneKeyQuery request, CancellationToken cancellationToken)
    {
        var key = await DB.Find<Prodavnica.Domain.Entities.Key>().OneAsync(request.KeyId, cancellationToken);
        if (key == null) throw new Exception("Key does not exist!");
        return await _mapper.Map<Task<KeyDetailsDto>>(key);
    }
}