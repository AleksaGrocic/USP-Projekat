using MongoDB.Entities;

namespace Prodavnica.Domain.Entities;

public class BaseEntity : Entity, ICreatedOn, IModifiedOn
{
    public DateTime CreatedOn { get; set; }
    public DateTime ModifiedOn { get; set; }
}