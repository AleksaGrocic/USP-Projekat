using AutoMapper;
using MediatR;
using Prodavnica.Application.Common.Dto.Users;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Administrator.Commands;

public record UpdateAdministratorCommand(UpdateUserDto user) : IRequest
{
}

public class UpdateAdministratorHandler : IRequestHandler<UpdateAdministratorCommand>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UpdateAdministratorHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAdministratorCommand request, CancellationToken cancellationToken)
    {

        var updatedUser = _mapper.Map<Domain.Entities.User>(request.user);

        await _userService.UpdateUser(updatedUser);
    }
}