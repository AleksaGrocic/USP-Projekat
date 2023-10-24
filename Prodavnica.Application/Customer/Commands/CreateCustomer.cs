using MediatR;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Customer.Commands;

public record CreateCustomer(string EmailAddress, int Wallet) : IRequest;

public class CreateCustomerHandler : IRequestHandler<CreateCustomer>
{
    
    private readonly IUserService _userService;

    public CreateCustomerHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateCustomer request, CancellationToken cancellationToken)
    {
        await _userService.CreateUserAsync(request.EmailAddress,request.Wallet,
            new List<string> {  Common.Constants.ProdavnicaAuthorization.User });
    }
}