using AutoMapper;
using MediatR;
using Prodavnica.Application.Common.Dto.Users;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Administrator.Queries;

public record GetOneUserQuery(string UserId): IRequest<UserDto>;

public class GetOneUserQueryHandler : IRequestHandler<GetOneUserQuery, UserDto>
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetOneUserQueryHandler(IMapper mapper,  IUserService userService)
    {
        _userService= userService;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetOneUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(request.UserId);

        if (user == null)
        {
            throw new Exception("User does not exist!");
        }

        
        var userDto = _mapper.Map<UserDto>(user);

        return userDto;
    }
}