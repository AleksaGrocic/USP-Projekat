using MediatR;
using MongoDB.Entities;

namespace Prodavnica.Application.Category.Commands;

public record CreateCategoryCommand(string Name) : IRequest;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var data = new Domain.Entities.Category(request.Name);
        
        
        await data.SaveAsync(cancellation: cancellationToken);
    }
}