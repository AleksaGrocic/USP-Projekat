using MongoDB.Entities;

namespace Prodavnica.Domain.Entities;

[Collection("vendors")]
public class Vendor : BaseEntity
{
    private Vendor()
    {

    }

    public Vendor(string name, bool active)
    {
        Name = name;
        Active = active;
    }

    [Field("name")]
    public string Name { get; set; }
    [Field("active")]
    public bool Active { get; set; }
}