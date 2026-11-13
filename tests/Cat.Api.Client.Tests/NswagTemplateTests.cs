using System.Diagnostics;
using System.IO.Compression;
using System.Text.Json;

namespace Cat.Api.Client.Tests;

/// <summary>
/// Checks the NSwag settings template of the package and the targets file that copies it to a client project.
/// </summary>
[TestFixture]
public class NswagTemplateTests
{
    private string _buildFolder = null!;
    private string _projectFolder = null!;

    [SetUp]
    public void SetUp()
    {
        _buildFolder = Path.Combine(FindRepositoryRoot(), "modules", "Cat.Api.Client", "Cat.Api.Client", "build");
        _projectFolder = Directory.CreateTempSubdirectory("cat-nswag-template-").FullName;
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(_projectFolder, recursive: true);
    }

    [Test]
    public void TheTemplate_IsOffByDefault()
    {
        RunTarget(optIn: false);

        Assert.That(File.Exists(NswagFile), Is.False);
    }

    [Test]
    public void TheTemplate_IsCopiedWhenTheProjectTurnsItOn()
    {
        RunTarget(optIn: true);

        Assert.That(File.Exists(NswagFile), Is.True);
        Assert.That(File.ReadAllText(NswagFile), Is.EqualTo(File.ReadAllText(TemplateFile)));
    }

    [Test]
    public void AnExistingNswagFile_IsNeverOverwritten()
    {
        File.WriteAllText(NswagFile, "{ \"mine\": true }");

        RunTarget(optIn: true);

        Assert.That(File.ReadAllText(NswagFile), Is.EqualTo("{ \"mine\": true }"));
    }

    [Test]
    public void TheTemplate_LeavesOutTheTypesTheModuleProvides()
    {
        using var template = JsonDocument.Parse(File.ReadAllText(TemplateFile));
        var settings = template.RootElement.GetProperty("codeGenerators").GetProperty("openApiToCSharpClient");

        var excluded = settings.GetProperty("excludedTypeNames").EnumerateArray().Select(name => name.GetString());
        var usings = settings.GetProperty("additionalNamespaceUsages").EnumerateArray().Select(name => name.GetString());

        Assert.That(excluded, Is.EquivalentTo(new[] { "CatProblemDetails", "ICatError" }));
        Assert.That(usings, Does.Contain("Cat.Api.Client"));
        Assert.That(settings.GetProperty("exceptionClass").GetString(), Is.EqualTo(nameof(CatApiException)));
    }

    [Test]
    public void ThePackage_ShipsTheBuildFolder()
    {
        var project = Path.Combine(_buildFolder, "..", "Cat.Api.Client.csproj");

        Run("pack", project, "-c", "Release", "-o", _projectFolder, "-nologo", "-v:q");

        var package = Directory.GetFiles(_projectFolder, "*.nupkg").Single();
        using var archive = ZipFile.OpenRead(package);
        var entries = archive.Entries.Select(entry => entry.FullName).ToList();

        // NuGet only imports a targets file that sits in build and is named after the package id.
        Assert.That(entries, Does.Contain("build/gmarginet.Cat.Api.Client.targets"));
        Assert.That(entries, Does.Contain("build/nswag.template.json"));
    }

    private string NswagFile => Path.Combine(_projectFolder, "nswag.json");

    private string TemplateFile => Path.Combine(_buildFolder, "nswag.template.json");

    /// <summary>
    /// Runs the copy target of the targets file in a bare project, like a client project would on its first build.
    /// </summary>
    private void RunTarget(bool optIn)
    {
        var targets = Path.Combine(_buildFolder, "gmarginet.Cat.Api.Client.targets");
        var optInProperty = optIn ? "<PropertyGroup><CatApiClientNswagTemplate>true</CatApiClientNswagTemplate></PropertyGroup>" : string.Empty;
        var project = Path.Combine(_projectFolder, "Client.proj");
        File.WriteAllText(project, $"<Project>{optInProperty}<Import Project=\"{targets}\" /></Project>");

        // No node reuse. On Linux the MSBuild worker nodes stay alive for 15 minutes and keep the output pipes open,
        // so every run would wait for them.
        Run("msbuild", project, "-t:CatApiClientCopyNswagTemplate", "-nologo", "-v:minimal", "-nodeReuse:false");
    }

    /// <summary>
    /// Runs a dotnet command and fails the test with its output when it does not succeed.
    /// </summary>
    private static void Run(params string[] arguments)
    {
        var start = new ProcessStartInfo(Environment.GetEnvironmentVariable("DOTNET_HOST_PATH") ?? "dotnet")
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        start.Environment["MSBUILDDISABLENODEREUSE"] = "1";
        foreach (var argument in arguments)
            start.ArgumentList.Add(argument);

        using var process = Process.Start(start)!;
        var output = process.StandardOutput.ReadToEndAsync();
        var error = process.StandardError.ReadToEndAsync();
        process.WaitForExit();

        Assert.That(process.ExitCode, Is.EqualTo(0), output.Result + error.Result);
    }

    private static string FindRepositoryRoot()
    {
        var folder = new DirectoryInfo(AppContext.BaseDirectory);
        while (folder is not null && !File.Exists(Path.Combine(folder.FullName, "CleanArchitectureToolkit.slnx")))
            folder = folder.Parent;

        return folder?.FullName ?? throw new InvalidOperationException("The root of the repository was not found.");
    }
}
