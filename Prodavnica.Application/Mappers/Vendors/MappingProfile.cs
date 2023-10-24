using AutoMapper;
using Prodavnica.Application.Common.Dto.Vendor;

namespace Prodavnica.Application.Mappers.Vendors;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateVendorDto, Domain.Entities.Vendor>().ReverseMap();
    }
    
}