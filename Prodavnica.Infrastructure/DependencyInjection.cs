﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using Prodavnica.Application.Common.Interfaces;
using Prodavnica.Infrastructure.Auth;
using Prodavnica.Infrastructure.Configuration;

namespace Prodavnica.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var mongoDbConfiguration = new MongoDbConfiguration();
        configuration.GetSection("MongoDbConfiguration")
            .Bind(mongoDbConfiguration);
        
        Task.Run(async () =>
            {
                await DB.InitAsync(mongoDbConfiguration.DatabaseName!,
                    MongoClientSettings.FromConnectionString(mongoDbConfiguration.ConnectionString));
            })
            .GetAwaiter()
            .GetResult();
        
        serviceCollection.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        serviceCollection.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConfiguration"));

        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();

        return serviceCollection;
    }
}