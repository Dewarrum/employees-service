using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Application.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Web.Auth;

public sealed class AuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    IUsersService usersService)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authorizationHeader = Request.Headers.Authorization.OfType<string>().ToList();
        if (authorizationHeader.Count != 1)
        {
            return AuthenticateResult.Fail("Invalid Authorization header");
        }

        var authorization = authorizationHeader[0];
        if (!authorization.StartsWith("Basic "))
        {
            return AuthenticateResult.Fail("Invalid Authorization header");
        }

        var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authorization[6..])).Split(':');
        if (credentials.Length != 2)
        {
            return AuthenticateResult.Fail("Invalid Authorization header");
        }

        var user = await usersService.Get(credentials[0], credentials[1]);
        if (user is null)
        {
            return AuthenticateResult.Fail("Invalid username or password");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name)
        };

        var identity = new ClaimsIdentity(claims, "Basic");
        var principal = new ClaimsPrincipal(identity);

        return AuthenticateResult.Success(new AuthenticationTicket(principal, "Basic"));
    }
}