using MediatR;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Seller.Commands;

public record CreateSeller(string EmailAddress, int Wallet) : IRequest;

public class CreateSellerHandler : IRequestHandler<CreateSeller>
{
    
    private readonly IUserService _userService;

    public CreateSellerHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateSeller request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.EmailAddress,request.Wallet,
            new List<string> { Common.Constants.ProdavnicaAuthorization.Seller });
    }

    
}