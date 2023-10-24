using Prodavnica.Application.Key.Queries;

namespace Prodavnica.BaseTests.Builders.Queries;

public class GetKeyPagedListQueryBuilder
{
    private int _pageSize = 7;
    private int _pageNumber = 1;
    private string _searchQuery = "";

    public GetKeyPagedListQuery Build() => new(_pageSize,
        _pageNumber,
        _searchQuery);

    public GetKeyPagedListQueryBuilder WithPageSize(int pageSize)
    {
        _pageSize = pageSize;
        return this;
    }

    public GetKeyPagedListQueryBuilder WithPageNumber(int pageNumber)
    {
        _pageNumber = pageNumber;
        return this;
    }

    public GetKeyPagedListQueryBuilder WithStringQuery(string searchQuery)
    {
        _searchQuery = searchQuery;
        return this;
    }
}
