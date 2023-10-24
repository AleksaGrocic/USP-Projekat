using MongoDB.Entities;
using Prodavnica.Domain.Entities;
using Prodavnica.Domain.Entities;

namespace Prodavnica.BaseTests.Data;

public class KeyBuilder
{
    public Key Build()
    {
        return new Key
        {
            Name = "key1",
            Price = 100,
            ExpDate = default,
            Vendor = new One<Vendor>(),
            Category = new One<Category>(),
            Description = "desc",
            Image = "img1",
            Sublicense = true,
            Seller = default,

        };
    }
}
