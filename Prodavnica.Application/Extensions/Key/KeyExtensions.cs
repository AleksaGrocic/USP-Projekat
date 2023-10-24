using MongoDB.Entities;
using Prodavnica.Application.Key.Queries;

namespace Prodavnica.Application.Extensions.Key;

public static class KeyExtensions
{
    public static PagedSearch<Prodavnica.Domain.Entities.Key, 
        Prodavnica.Domain.Entities.Key> ApplyFilters(this PagedSearch<Prodavnica.Domain.Entities.Key, 
        Prodavnica.Domain.Entities.Key> query, GetKeyPagedListQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Prodavnica.Domain.Entities.Key>)query.Match(x =>
                x.Name
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()));
        }

        return query;
    }
}