using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using MongoDB.Entities;
using Prodavnica.Application.Key.Queries;
using Prodavnica.BaseTests;
using Prodavnica.BaseTests.Builders.Queries;
using Prodavnica.BaseTests.Data;

namespace Prodavnica.UnitTests.Keys.Queries;

public class GetKeyPagedQueryTests : Base
{
    [Fact]
    public async Task GetKeyPagedListQuery_Filters_ReturnUserPagedList()
    {
        //Given (Arrange) - what is part of request
        var key = new KeyBuilder().Build();
        await key.SaveAsync();
    
        //When (Act) - what we do with that data
        var handler = new GetKeyPagedQueryHandler(Mapper);
        var query = new GetKeyPagedListQueryBuilder().Build();
        var response = await handler.Handle(query,
            new CancellationToken());
        
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
    
        response.Should().NotBeNull();
        response.Key.Should().NotBeNull();
        response.Key.Should().HaveCount(1);
        
        await DB.Database("ProdavnicaUspTests").Client.DropDatabaseAsync("ProdavnicaUspTests");
    }
}
