using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Prodavnica.Application.Common.Dto.Keys;
using Prodavnica.BaseTests;

namespace Prodavnica.UnitTests.Keys.Queries;

public class GetKeyListQueryTests : Base
{
    private const string BaseUrl = "/key/List";

    [Fact]
    public async Task GetKeyListQuery_Filters_ReturnKeyList()
    {
        //Given (Arrange) - what is part of request
        
        //When (Act) - what we do with that data
        var response = await AnonymousClient.GetAsync(BaseUrl);
    
        //Then (Assert) - what is response
        using var _ = new AssertionScope();
    
        response.StatusCode
            .Should()
            .Be(HttpStatusCode.OK);
        
        var result = await response.Content.ReadFromJsonAsync<KeyListDto>();
    }
}
