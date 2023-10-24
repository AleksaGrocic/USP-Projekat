using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Prodavnica.Auth.Options;

namespace Prodavnica.Auth.Providers;

public class PasswordlessLoginTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
{
    public PasswordlessLoginTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<PasswordlessLoginTokenProviderOptions> options, ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider,
        options,
        logger)
    {
    }
}
