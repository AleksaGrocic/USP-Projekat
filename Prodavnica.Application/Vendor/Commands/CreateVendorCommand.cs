using MediatR;
using MongoDB.Entities;

namespace Prodavnica.Application.Vendor.Commands;

public record CreateVendorCommand(string Name,bool Active) : IRequest;

public class CreateVendorHandler : IRequestHandler<CreateVendorCommand>
{
    public async Task Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var data = new Prodavnica.Domain.Entities.Vendor(request.Name,request.Active);        
        
        await data.SaveAsync(cancellation: cancellationToken);
    }
}