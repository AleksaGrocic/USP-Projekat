using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Vendor;

namespace Prodavnica.Application.Vendor.Queries;

public record GetVendorQuery(string VendorId) : IRequest<VendorDto>;
public class GetVendorQueryHandler: IRequestHandler<GetVendorQuery,VendorDto>
{
    public async Task<VendorDto> Handle(GetVendorQuery request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>().OneAsync(request.VendorId, cancellationToken);
        if (vendor ==null)
        {
            throw new Exception("Vendor doesn't exist");
        }


        return new VendorDto(vendor.Name,
            vendor.Active);
    }
}
