using MongoDB.Entities;

namespace Prodavnica.Domain.Entities;

[Collection("categories")]
public class Category : BaseEntity
{
    private Category()
    {

    }

    public Category(string name)
    {
        Name = name;
    }

    [Field("name")]
    public string Name { get; set; }
    
}