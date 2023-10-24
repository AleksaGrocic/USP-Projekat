using AutoMapper;
using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Vendor;
using Prodavnica.Application.Common.Exceptions;

namespace Prodavnica.Application.Vendor.Commands;

public record UpdateVendorCommand(UpdateVendorDto Vendor) : IRequest;

public class UpdateVendorHandler: IRequestHandler<UpdateVendorCommand>
{
    private readonly IMapper _mapper;

    public UpdateVendorHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Prodavnica.Domain.Entities.Vendor>().OneAsync(request.Vendor.VendorId, cancellationToken);
        if (vendor== null)
        {
            throw new NotFoundException("Vendor not Found");
        }

        _mapper.Map(request.Vendor, vendor);

        await vendor.SaveAsync(cancellation: cancellationToken);

    }
}
