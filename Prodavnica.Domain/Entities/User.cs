using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Prodavnica.Domain.Entities;

[CollectionName("users")]
public class User : MongoIdentityUser<Guid>
{

    public User()
    {
        
    }

    public string? Name { get; set; }
    
    public int Wallet { get; set; }
    
    public List<string> Role { get; set; }
    
}