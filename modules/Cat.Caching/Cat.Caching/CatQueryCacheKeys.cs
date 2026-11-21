using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Cat.Caching.Abstractions;

namespace Cat.Caching;

/// <summary>
/// Builds the key of a cache entry. The key holds the query type name and a hash of the user and the query.
/// The hash keeps personal data out of the key, and out of the distributed cache. A key is never logged or used as a tag.
/// </summary>
internal static class CatQueryCacheKeys
{
    private const string NoUser = "-";

    public static string Build(object query, CatQueryCacheRule rule, string? userId)
    {
        var queryType = query.GetType();
        var queryPart = rule.KeyFunction != null ? rule.KeyFunction(query) : Serialize(query, queryType);
        var userPart = rule.IsShared ? string.Empty : string.IsNullOrEmpty(userId) ? NoUser : userId;

        using var sha = SHA256.Create();
        var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(userPart + "\n" + queryPart));
        return "cat.caching:" + queryType.FullName + ":" + BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    private static string Serialize(object query, Type queryType)
    {
        try
        {
            return JsonSerializer.Serialize(query, queryType);
        }
        catch (Exception exception) when (exception is NotSupportedException || exception is JsonException || exception is InvalidOperationException)
        {
            throw new InvalidOperationException(
                $"The query {queryType.Name} cannot be used for a cache key, because it cannot be serialized. " +
                "Set a key function in the registration of the query type, for example Cache<" + queryType.Name + ">(rule => rule.Key(query => ...)).",
                exception);
        }
    }
}
