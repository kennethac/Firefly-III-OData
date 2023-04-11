using System.Text;
using System.Text.RegularExpressions;

namespace firefly_iii_odata.Crypto;

/// <summary>
/// Excel supports 2 authentication methods for OData: Basic and Organizational Acounts.
/// The Basic one is bad because Firefly III doesn't support that + it's basic authentication.
/// The Organizational Accounts one could theoretically work, but it doesn't because
/// Microsoft only trusts its own AD services to authenticate against. If you provide Firefly III
/// It tells you it doesn't trust it.
/// <para>
/// As a disgusting work around, this middleware looks for Basic authorization headers and maps
/// them to Bearer authentication headers, where the Bearer token is the user from the basic header.
/// To authentiate from Excel, you choose Basic and put your personal access token in as the user
/// and nothing in as the password.
/// </para>
/// </summary>
public class BasicAuthTranslator
{
    private static readonly Regex BasicExtractor = new Regex("Basic (.*)");
    private readonly RequestDelegate _next;

    public BasicAuthTranslator(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // var authHeader = context.Request.Headers.Authorization;
        var headerNames = context.Request.Headers.Keys;
        Console.WriteLine($"All Keys: {string.Join(";", headerNames)}");
        foreach (var n in headerNames)
        {
            Console.WriteLine($"{n}: {context.Request.Headers[n]}");
        }
        var authHeader = context.Request.Headers.Authorization;
        if (authHeader.Count > 0
            && authHeader[0] is not null
            && BasicExtractor.Match(authHeader[0]!) is { Success: true, Groups: { Count: > 1 } groups })
        {
            var basicValue = groups[1].Value;
            var token = Encoding.UTF8.GetString(Convert.FromBase64String(basicValue))[..^1]; // Have to remove the trailing ';'
            context.Request.Headers.Remove("Authorization");
            context.Request.Headers.Authorization = $"Bearer {token}";
        }

        await _next(context).ConfigureAwait(false);
    }
}