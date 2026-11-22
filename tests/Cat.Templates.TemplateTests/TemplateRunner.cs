using System.Diagnostics;
using System.Text;

namespace Cat.Templates.TemplateTests;

/// <summary>
/// Installs the template pack into its own template hive, so the templates of the developer are not touched,
/// and runs <c>dotnet</c> in a folder. The packed modules are the package source of every generated solution.
/// </summary>
public sealed class TemplateRunner
{
    private static readonly TimeSpan Timeout = TimeSpan.FromMinutes(10);

    private readonly string _hive;
    private readonly string _packageFeed;

    public TemplateRunner(string root, string packageFeed)
    {
        _hive = Path.Combine(root, "hive");
        _packageFeed = packageFeed;
        Root = root;
    }

    public string Root { get; }

    /// <summary>The pack, taken from the environment. It is null when the packs were not made, and the tests are skipped then.</summary>
    public static string? PackPath => Environment.GetEnvironmentVariable("CAT_TEMPLATE_PACK");

    /// <summary>The folder with the packed modules, taken from the environment.</summary>
    public static string? PackageFeed => Environment.GetEnvironmentVariable("CAT_PACKAGE_FEED");

    public async Task InstallAsync(string packPath)
    {
        Directory.CreateDirectory(Root);
        var result = await RunAsync("dotnet", $"new install \"{packPath}\" --debug:custom-hive \"{_hive}\"", Root);
        Assert.That(result.ExitCode, Is.EqualTo(0), result.Output);
    }

    /// <summary>Creates a solution with <c>cat-service</c> in a new folder and writes a NuGet.config that points to the packed modules.</summary>
    public async Task<string> CreateServiceAsync(string name, string options)
    {
        var folder = Path.Combine(Root, name);
        Directory.CreateDirectory(folder);
        var result = await RunAsync("dotnet", $"new cat-service -n {name} -o \"{folder}\" {options} --debug:custom-hive \"{_hive}\"", Root);
        Assert.That(result.ExitCode, Is.EqualTo(0), result.Output);

        await File.WriteAllTextAsync(Path.Combine(folder, "NuGet.config"), $"""
            <?xml version="1.0" encoding="utf-8"?>
            <configuration>
              <packageSources>
                <clear />
                <add key="cat-local" value="{_packageFeed}" />
                <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
              </packageSources>
            </configuration>
            """);
        return folder;
    }

    public Task<ProcessResult> DotnetAsync(string arguments, string workingDirectory) => RunAsync("dotnet", arguments, workingDirectory);

    private static async Task<ProcessResult> RunAsync(string fileName, string arguments, string workingDirectory)
    {
        var startInfo = new ProcessStartInfo(fileName, arguments)
        {
            WorkingDirectory = workingDirectory,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false
        };
        // The generated solution must not pick up settings of the process that runs the test.
        startInfo.Environment["DOTNET_CLI_TELEMETRY_OPTOUT"] = "1";
        startInfo.Environment["DOTNET_NOLOGO"] = "1";
        startInfo.Environment["MSBUILDDISABLENODEREUSE"] = "1";

        using var process = Process.Start(startInfo) ?? throw new InvalidOperationException($"Could not start {fileName}.");
        var output = new StringBuilder();
        process.OutputDataReceived += (_, e) => { if (e.Data is not null) { lock (output) { output.AppendLine(e.Data); } } };
        process.ErrorDataReceived += (_, e) => { if (e.Data is not null) { lock (output) { output.AppendLine(e.Data); } } };
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        using var cts = new CancellationTokenSource(Timeout);
        try
        {
            await process.WaitForExitAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            return new ProcessResult(-1, output + Environment.NewLine + $"Timed out after {Timeout}.");
        }

        return new ProcessResult(process.ExitCode, output.ToString());
    }
}

public sealed record ProcessResult(int ExitCode, string Output);
