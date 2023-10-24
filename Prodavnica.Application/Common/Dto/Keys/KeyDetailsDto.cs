namespace Prodavnica.Application.Common.Dto.Keys;

public record KeyDetailsDto(string KeyName, string VendorName, int Price, string CategoryName, DateOnly ExpDate,
                            string Description, string Image, bool Sublicense, IEnumerable<string?>Seller);