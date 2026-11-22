namespace Cat.Templates.TemplateTests;

/// <summary>
/// Creates systems with <c>cat-system</c>, which runs <c>cat-service</c> for its first service, and builds them.
/// The AppHost is only built, never started. The tests need the packs that Cat makes, so they are skipped when the environment variables are missing.
/// Run them with <c>dotnet cake --target=TemplateTest</c>.
/// </summary>
[TestFixture]
public class SystemTemplateTests
{
    private TemplateRunner _runner = null!;

    public sealed record SystemOptions(string Database, string Approach, bool Messages, string Framework = "net11.0", bool Everything = false)
    {
        public string Name => $"Contoso.Sys{Database[..2]}{Approach[..1]}{(Messages ? "M" : "N")}{Framework.Replace(".", "")}{(Everything ? "E" : "D")}";

        public string Arguments => $"--Database {Database} --Approach {Approach} --Messages {Messages.ToString().ToLowerInvariant()} --Framework {Framework}"
                                   + (Everything ? " --Jobs true --Tests true --ExampleRequest true" : " --Jobs false --Tests false --ExampleRequest false");

        public override string ToString() => Name;
    }

    /// <summary>
    /// Every branch of the AppHost and of the post action: database, approach and messages, 8 systems.
    /// The service options that do not change the AppHost are on in half of them, and two systems use net10.0.
    /// </summary>
    public static IEnumerable<SystemOptions> Combinations()
    {
        foreach (var database in new[] { "SqlServer", "PostgreSQL" })
        {
            foreach (var approach in new[] { "CodeFirst", "DatabaseFirst" })
            {
                foreach (var messages in new[] { false, true })
                {
                    var everything = messages;
                    var framework = database == "PostgreSQL" && approach == "CodeFirst" ? "net10.0" : "net11.0";
                    yield return new SystemOptions(database, approach, messages, framework, everything);
                }
            }
        }
    }

    [Test]
    public async Task System_WithoutAGitIgnore_ShouldNotWriteOne()
    {
        var folder = await _runner.CreateSystemAsync("Contoso.SysNoIgnore", "Orders", "--GitIgnore false --Tests false --ExampleRequest false");

        Assert.That(File.Exists(Path.Combine(folder, ".gitignore")), Is.False);
        Assert.That(File.Exists(Path.Combine(folder, "Contoso.SysNoIgnore.Orders.README.md")), Is.True);
    }

    [OneTimeSetUp]
    public async Task InstallThePack()
    {
        if (string.IsNullOrWhiteSpace(TemplateRunner.PackPath) || string.IsNullOrWhiteSpace(TemplateRunner.PackageFeed))
        {
            Assert.Ignore("CAT_TEMPLATE_PACK and CAT_PACKAGE_FEED are not set. Run dotnet cake --target=TemplateTest.");
        }

        var root = Path.Combine(Path.GetTempPath(), "cat-system-tests-" + Guid.NewGuid().ToString("N")[..8]);
        _runner = new TemplateRunner(root, TemplateRunner.PackageFeed!);
        await _runner.InstallAsync(TemplateRunner.PackPath!);
    }

    [OneTimeTearDown]
    public void RemoveTheFolders()
    {
        if (_runner is not null && Directory.Exists(_runner.Root))
        {
            Directory.Delete(_runner.Root, recursive: true);
        }
    }

    [TestCaseSource(nameof(Combinations))]
    public async Task System_ShouldBuildWithItsFirstService(SystemOptions options)
    {
        var folder = await _runner.CreateSystemAsync(options.Name, "Orders", options.Arguments);
        var system = options.Name;

        // The post action made the service in the same folder, and added its projects to the solution of the system.
        Assert.That(File.Exists(Path.Combine(folder, $"{system}.Orders.README.md")), Is.True, "The first service was not created.");
        var solutionText = await File.ReadAllTextAsync(Path.Combine(folder, $"{system}.slnx"));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(solutionText, Does.Contain($"{system}.Orders.Api.csproj"));
            Assert.That(solutionText, Does.Contain($"{system}.AppHost.csproj"));
            Assert.That(solutionText, Does.Contain($"{system}.Api.Gateway.csproj"));
        }

        Assert.That(await File.ReadAllTextAsync(Path.Combine(folder, ".gitignore")), Does.Contain("cat-service*.rsp"));

        var build = await _runner.DotnetAsync("build --nologo", folder);
        Assert.That(build.ExitCode, Is.EqualTo(0), build.Output);

        if (options.Everything)
        {
            var test = await _runner.DotnetAsync("test --no-build --nologo", folder);
            Assert.That(test.ExitCode, Is.EqualTo(0), test.Output);
        }
    }
}
