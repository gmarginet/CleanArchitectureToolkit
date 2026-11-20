using System;

namespace Cat.IntegrationTesting;

/// <summary>
/// Tells where the tests run, so a missing Docker can fail on a build server and be ignored on a developer machine.
/// </summary>
public static class CatTestEnvironment
{
    /// <summary>
    /// Gets a value that says whether the tests run on a build server. It is <c>true</c> when the <c>CI</c> environment variable is set to a value other than <c>false</c> or <c>0</c>.
    /// </summary>
    public static bool IsContinuousIntegration => IsContinuousIntegrationValue(Environment.GetEnvironmentVariable("CI"));

    internal static bool IsContinuousIntegrationValue(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        var trimmed = value!.Trim();
        return !string.Equals(trimmed, "false", StringComparison.OrdinalIgnoreCase) && trimmed != "0";
    }

    /// <summary>
    /// Gets the message that a test shows when it is ignored because Docker is missing.
    /// </summary>
    /// <param name="reason">The message of <see cref="CatContainerUnavailableException"/>.</param>
    /// <returns>The text for the ignore.</returns>
    public static string IgnoreMessage(string reason) => "Docker is not available, so the integration test is ignored. " + reason;

    /// <summary>
    /// Creates a unique database name that is safe in SQL Server and PostgreSQL.
    /// </summary>
    /// <returns>A name such as <c>cat_9f2c1d0b6a7e4c3f8b5d2a1e0c9b8a7d</c>.</returns>
    public static string NewDatabaseName() => "cat_" + Guid.NewGuid().ToString("N");
}
