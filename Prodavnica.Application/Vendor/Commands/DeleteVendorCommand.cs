using AutoMapper;
using MediatR;
using MongoDB.Entities;

namespace Prodavnica.Application.Vendor.Commands;

public record DeleteVendorCommand(string VendorId) : IRequest;

public class DeleteVendorHandler : IRequestHandler<DeleteVendorCommand>
{
    private readonly IMapper _mapper;

    public DeleteVendorHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Prodavnica.Domain.Entities.Vendor>(x => x.ID != null && x.ID.Equals(request.VendorId),
            cancellation: cancellationToken);
    }
}