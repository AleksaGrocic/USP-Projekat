using AutoMapper;
using Prodavnica.Application.Common.Dto;
using Prodavnica.Application.Common.Dto.Users;

namespace Prodavnica.Application.Mappers.Users;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDto, Prodavnica.Domain.Entities.User>()
            .ReverseMap();
        CreateMap<UpdateUserDto, Prodavnica.Domain.Entities.User>()
            .ReverseMap();

        CreateMap<IEnumerable<Prodavnica.Domain.Entities.User>, UserPagedListDto>()
            .ConstructUsing(x => ToUserPagedList(x));
    }

    private static UserDto GetUserDetails(Prodavnica.Domain.Entities.User user)
    {
        return new UserDto(user.Name,
            user.Email,
            user.Wallet,
            user.Role);
    }

    private static UserPagedListDto ToUserPagedList(IEnumerable<Prodavnica.Domain.Entities.User> users)
    {
        var userDtos = users.Select(GetUserDetails).ToList();

        return new UserPagedListDto(userDtos,
            new PaginationDto(0,
                0));
    }
}