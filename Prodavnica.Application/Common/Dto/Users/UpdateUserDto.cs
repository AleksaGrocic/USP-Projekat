namespace Prodavnica.Application.Common.Dto.Users;

public record UpdateUserDto(string? UserId, string? Name, string? Email, int? Wallet)
{
    internal UpdateUserDto AddLoggedInUser(string userId)
    {
        return this with { UserId = userId };
    }
}