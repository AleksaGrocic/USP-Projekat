namespace Prodavnica.Application.Common.Interfaces;

public interface IUserService
{
    Task CreateUserAsync(string emailAddress,int wallet, List<string> roles);
    Task<Domain.Entities.User?> GetUserAsync(string id);
    Task<Domain.Entities.User?> GetUserByEmailAsync(string id);
    Task<bool> IsInRoleAsync(Domain.Entities.User user, string roleName);
    Task DeleteUserAsync(string id);
    
    Task<List<Domain.Entities.User>> GetAllUsers();
    
    Task UpdateUser(Domain.Entities.User user);
    
    
}
