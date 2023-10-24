using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace Prodavnica.Domain.Entities;
[CollectionName("Roles")]
public class UserRole: MongoIdentityRole<Guid>
{
    
}