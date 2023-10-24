using MongoDB.Entities;
using Prodavnica.Application.Category.Queries;

namespace Prodavnica.Application.Extensions.Category;

public static class CategoryExtensions
{
    public static PagedSearch<Prodavnica.Domain.Entities.Category, 
                              Prodavnica.Domain.Entities.Category> ApplyFilters(this PagedSearch<Prodavnica.Domain.Entities.Category, 
                              Prodavnica.Domain.Entities.Category> query, GetCategoryPagedListQuery filters)
    {
        if (!string.IsNullOrEmpty(filters.SearchQuery))
        {
            query = (PagedSearch<Prodavnica.Domain.Entities.Category>)query.Match(x =>
                x.Name
                    .ToUpper()
                    .Contains(filters.SearchQuery.ToUpper()));
        }

        return query;
    }
}