using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Prodavnica.BaseTests;

public class Base
{
    public readonly HttpClient AnonymousClient;
    public readonly IMapper Mapper;
    public readonly IMediator Mediator;


    public Base()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        
        AnonymousClient = factory.CreateClient();
        Mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        Mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    }
}
