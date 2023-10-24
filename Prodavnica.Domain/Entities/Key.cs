using System.Net.Mime;
using MongoDB.Entities;

namespace Prodavnica.Domain.Entities;

[Collection("keys")]
public class Key : BaseEntity
{
    [Field("name")]
    public string Name { get; set; }

    [Field("price")]
    public int Price { get; set; }
    
    [Field("exp-date")]
    public DateOnly ExpDate { get; set; }

    [Field("vendor")]
    public One<Vendor> Vendor { get; set; }

    [Field("category")]
    public One<Category> Category { get; set; }
    
    [Field("description")]
    public string Description { get; set; }
    
    [Field("image")]
    public string Image { get; set; }
    
    [Field("sublicense")]
    public bool Sublicense { get; set; }
    
    public List<User> Seller {  get;  set;}

    public Key()
    {
        
    }
}