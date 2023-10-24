using AutoMapper;
using Prodavnica.Application.Common.Dto;
using Prodavnica.Application.Common.Dto.Keys;

namespace Prodavnica.Application.Mappers.Keys;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        
        CreateMap<KeyDetailsDto, Prodavnica.Domain.Entities.Key>().ReverseMap();
        CreateMap<Prodavnica.Domain.Entities.Key, Task<KeyDetailsDto>>()
            .ConstructUsing(x => GetKeyDetails(x));
        CreateMap<List<Prodavnica.Domain.Entities.Key>, KeyListDto>()
            .ConstructUsing(x => ToKeyList(x));
        CreateMap<IEnumerable<Prodavnica.Domain.Entities.Key>, KeyPagedListDto>()
            .ConstructUsing(x => ToCategoryPagedList(x));
    }

    private static async Task<KeyDetailsDto> GetKeyDetails(Prodavnica.Domain.Entities.Key key)
    {
        return new KeyDetailsDto(key.Name,
            (await key.Vendor.ToEntityAsync())!.Name,
            key.Price,
            (await key.Category.ToEntityAsync())!.Name,
            key.ExpDate,
            key.Description,
            key.Image,
            key.Sublicense,
            key.Seller.Select(x => x.Email));


    }

    private static KeyListDto ToKeyList(IEnumerable<Prodavnica.Domain.Entities.Key> keys)
    {

        var keyDtos = keys.Select(x => GetKeyDetails(x)
                .Result)
            .ToList();

        return new KeyListDto(keyDtos);
    }
    
    private static KeyPagedListDto ToCategoryPagedList(IEnumerable<Prodavnica.Domain.Entities.Key> keys)
    {
        var keyDtos = keys.Select(GetKeyDetails).ToList();
        
        return new KeyPagedListDto(keyDtos,
            new PaginationDto(0,
                0));
    }
}