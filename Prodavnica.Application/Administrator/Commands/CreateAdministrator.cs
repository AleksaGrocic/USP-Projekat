using MediatR;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Administrator.Commands;

public record CreateAdministrator(string EmailAddress, int Wallet) : IRequest;

public class CreateAdministratorHandler : IRequestHandler<CreateAdministrator>
{
    
    private readonly IUserService _userService;

    public CreateAdministratorHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateAdministrator request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.EmailAddress,request.Wallet,
            new List<string> { Common.Constants.ProdavnicaAuthorization.Administrator });
    }
}