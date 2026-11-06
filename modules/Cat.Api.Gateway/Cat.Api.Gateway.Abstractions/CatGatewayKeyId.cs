using System;
using System.Security.Cryptography;
using System.Text;

namespace Cat.Api.Gateway.Abstractions;

/// <summary>
/// Gives a signing key its id. The gateway and a service compute the same id from the same public key.
/// </summary>
/// <remarks>
/// The id is the thumbprint of the key as RFC 7638 describes it. A key you configure on a service therefore
/// matches the key id in the header of an assertion, without anyone choosing an id.
/// </remarks>
public static class CatGatewayKeyId
{
    /// <summary>
    /// Computes the id of a public P-256 key.
    /// </summary>
    /// <param name="x">The x coordinate of the public key.</param>
    /// <param name="y">The y coordinate of the public key.</param>
    /// <returns>The id as an unpadded base64url text.</returns>
    public static string ForP256(byte[] x, byte[] y)
    {
        if (x is null) throw new ArgumentNullException(nameof(x));
        if (y is null) throw new ArgumentNullException(nameof(y));

        var json = $"{{\"crv\":\"P-256\",\"kty\":\"EC\",\"x\":\"{ToBase64Url(x)}\",\"y\":\"{ToBase64Url(y)}\"}}";
        using var sha = SHA256.Create();
        return ToBase64Url(sha.ComputeHash(Encoding.UTF8.GetBytes(json)));
    }

    /// <summary>
    /// Encodes bytes as an unpadded base64url text.
    /// </summary>
    /// <param name="bytes">The bytes to encode.</param>
    /// <returns>The base64url text.</returns>
    public static string ToBase64Url(byte[] bytes)
    {
        if (bytes is null) throw new ArgumentNullException(nameof(bytes));

        return Convert.ToBase64String(bytes).TrimEnd('=').Replace('+', '-').Replace('/', '_');
    }
}
