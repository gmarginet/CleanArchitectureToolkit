using System.Security.Claims;
using Cat.EventProcessor.Abstractions;
using Cat.Messaging.Abstractions;
using Cat.Users;
using Cat.Users.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Cat.EventProcessor.Authorization;

/// <summary>
/// Default <see cref="ICatMessageAuthorizer"/>. It validates the token, sets the user of the scope and checks the policy and the rules
/// of the message type with <see cref="IAuthorizationService"/>.
/// </summary>
internal sealed class CatMessageAuthorizer : ICatMessageAuthorizer
{
    private readonly CatMessageTokenValidator _validator;
    private readonly IAuthorizationService _authorization;
    private readonly ICatUserAccessor _userAccessor;
    private readonly IOptions<CatUsersOptions> _usersOptions;
    private readonly IOptions<CatMessageAuthorizationOptions> _options;

    public CatMessageAuthorizer(CatMessageTokenValidator validator, IAuthorizationService authorization, ICatUserAccessor userAccessor,
        IOptions<CatUsersOptions> usersOptions, IOptions<CatMessageAuthorizationOptions> options)
    {
        _validator = validator;
        _authorization = authorization;
        _userAccessor = userAccessor;
        _usersOptions = usersOptions;
        _options = options;
    }

    /// <inheritdoc />
    public async Task<CatAuthorizationResult> AuthorizeAsync(CatIncomingMessage message, CatReceiveOptions options,
        CancellationToken cancellationToken = default)
    {
        var principal = new ClaimsPrincipal(new ClaimsIdentity());
        _userAccessor.User = CatUser.Anonymous;

        var token = ReadToken(message);
        if (token != null)
        {
            var (validated, failure) = await _validator.ValidateAsync(token, message, cancellationToken).ConfigureAwait(false);
            if (validated == null)
            {
                return CatAuthorizationResult.Unauthorized($"The token of the message is not valid. {failure}");
            }

            principal = validated;
            _userAccessor.User = new CatClaimsUser(principal, _usersOptions.Value);
        }

        if (!options.HasAuthorizationRule)
        {
            return _options.Value.DenyMessagesWithoutPolicy
                ? CatAuthorizationResult.Forbidden("The message type has no policy, and messages without a policy are denied.")
                : CatAuthorizationResult.Success;
        }

        if (!string.IsNullOrWhiteSpace(options.Policy))
        {
            var result = await _authorization.AuthorizeAsync(principal, null, options.Policy!).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                return Denied(principal, $"The policy {options.Policy} is not met.");
            }
        }

        foreach (var rule in options.AuthorizationRules.OfType<Action<AuthorizationPolicyBuilder>>())
        {
            var builder = new AuthorizationPolicyBuilder();
            rule(builder);
            var result = await _authorization.AuthorizeAsync(principal, null, builder.Build()).ConfigureAwait(false);
            if (!result.Succeeded)
            {
                return Denied(principal, "A rule of the message type is not met.");
            }
        }

        return CatAuthorizationResult.Success;
    }

    private static CatAuthorizationResult Denied(ClaimsPrincipal principal, string description) =>
        principal.Identity?.IsAuthenticated == true
            ? CatAuthorizationResult.Forbidden(description)
            : CatAuthorizationResult.Unauthorized($"{description} The message has no token.");

    private static string? ReadToken(CatIncomingMessage message)
    {
        foreach (var property in message.Properties)
        {
            if (!string.Equals(property.Key, CatMessageProperties.Authorization, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            const string prefix = "Bearer ";
            var value = property.Value?.Trim();
            if (value != null && value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) && value.Length > prefix.Length)
            {
                return value.Substring(prefix.Length).Trim();
            }
        }

        return null;
    }
}
