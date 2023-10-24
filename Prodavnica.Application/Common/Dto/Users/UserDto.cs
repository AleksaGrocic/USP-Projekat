namespace Prodavnica.Application.Common.Dto.Users;

public record UserDto(string Name, string Email, int Wallet,List<string>Role);