using MediatR;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.User.Commands;

public record DeleteUserCommand(string id) : IRequest
{
   
}

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    
   
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(request.id);
    }
}