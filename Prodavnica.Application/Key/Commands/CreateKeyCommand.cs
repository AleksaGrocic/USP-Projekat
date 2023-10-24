using MediatR;
using MongoDB.Entities;
using Prodavnica.Application.Common.Dto.Keys;
using Prodavnica.Application.Common.Interfaces;

namespace Prodavnica.Application.Key.Commands;

public record CreateKeyCommand(KeyDetailsDto KeyDetailsDto) : IRequest;


public class CreateKeyHandler : IRequestHandler<CreateKeyCommand>
{
    
    private readonly IUserService _userService;
    public CreateKeyHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task Handle(CreateKeyCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Prodavnica.Domain.Entities.Vendor>()
            .OneAsync(request.KeyDetailsDto.VendorName,
                cancellationToken);
        
        var category = await DB.Find<Prodavnica.Domain.Entities.Category>()
            .OneAsync(request.KeyDetailsDto.CategoryName,
                cancellationToken);

        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }
        
        if (category == null)
        {
            throw new Exception("Category not found");
        }
        var seller = new List<Domain.Entities.User>();
        foreach (var item in request.KeyDetailsDto.Seller)
        {
            var user = await _userService.GetUserAsync(item);
                
            if (user == null)
            {
                throw new Exception("User is not found");
            }

            seller.Add(user);
        }
        
        var data = new Prodavnica.Domain.Entities.Key
        {
            Name = request.KeyDetailsDto.KeyName,
            Vendor = new One<Prodavnica.Domain.Entities.Vendor>(vendor),
            Price = request.KeyDetailsDto.Price,
            Category = new One<Prodavnica.Domain.Entities.Category>(category),
            ExpDate = request.KeyDetailsDto.ExpDate,
            Description = request.KeyDetailsDto.Description,
            Image = request.KeyDetailsDto.Image,
            Sublicense = request.KeyDetailsDto.Sublicense
        };

        data.Seller = new List<Domain.Entities.User>();
        
        data.Seller.AddRange(seller);
        await data.SaveAsync(cancellation: cancellationToken);

    }
}
