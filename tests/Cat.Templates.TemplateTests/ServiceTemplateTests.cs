namespace Cat.Templates.TemplateTests;

/// <summary>
/// Creates services with <c>cat-service</c>, builds them against the packed modules and runs their own tests.
/// The tests need the packs that Cake makes, so they are skipped when the environment variables are missing.
/// Run them with <c>dotnet cake --target=TemplateTest</c>.
/// </summary>
[TestFixture]
public class ServiceTemplateTests
{
    private TemplateRunner _runner = null!;

    public sealed record ServiceOptions(string Database, string Framework, bool Tests, bool ApiClient, bool ExampleRequest)
    {
        public string Name => $"S{Database}{Framework.Replace(".", "")}T{(Tests ? 1 : 0)}C{(ApiClient ? 1 : 0)}E{(ExampleRequest ? 1 : 0)}";

        public string Arguments => $"--Database {Database} --Framework {Framework} --Tests {Tests.ToString().ToLowerInvariant()} "
                                   + $"--ApiClient {ApiClient.ToString().ToLowerInvariant()} --ExampleRequest {ExampleRequest.ToString().ToLowerInvariant()}";

        public override string ToString() => Name;
    }

    /// <summary>
    /// Every database and target framework with all flags off, then with all flags on, and each flag on alone with the defaults.
    /// A clash that only shows in a rare mix of flags can slip through, and that is accepted.
    /// </summary>
    public static IEnumerable<ServiceOptions> Combinations()
    {
        foreach (var database in new[] { "SqlServer", "PostgreSQL" })
        {
            foreach (var framework in new[] { "net10.0", "net11.0" })
            {
                yield return new ServiceOptions(database, framework, false, false, false);
                yield return new ServiceOptions(database, framework, true, true, true);
            }
        }

        yield return new ServiceOptions("SqlServer", "net11.0", true, false, false);
        yield return new ServiceOptions("SqlServer", "net11.0", false, true, false);
        yield return new ServiceOptions("SqlServer", "net11.0", false, false, true);
    }

    [OneTimeSetUp]
    public async Task InstallThePack()
    {
        if (string.IsNullOrWhiteSpace(TemplateRunner.PackPath) || string.IsNullOrWhiteSpace(TemplateRunner.PackageFeed))
        {
            Assert.Ignore("CAT_TEMPLATE_PACK and CAT_PACKAGE_FEED are not set. Run dotnet cake --target=TemplateTest.");
        }

        var root = Path.Combine(Path.GetTempPath(), "cat-template-tests-" + Guid.NewGuid().ToString("N")[..8]);
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
    public async Task Service_ShouldBuildAndPassItsTests(ServiceOptions options)
    {
        var folder = await _runner.CreateServiceAsync(options.Name, options.Arguments);

        var build = await _runner.DotnetAsync("build --nologo", folder);
        Assert.That(build.ExitCode, Is.EqualTo(0), build.Output);

        if (options.Tests)
        {
            var test = await _runner.DotnetAsync("test --no-build --nologo", folder);
            Assert.That(test.ExitCode, Is.EqualTo(0), test.Output);
        }
    }

    [Test]
    public async Task Service_WithAPrefixedName_ShouldNameTheProjectsAfterTheFullName()
    {
        var folder = await _runner.CreateServiceAsync("Contoso.Shop.Orders", string.Empty);

        Assert.That(Directory.Exists(Path.Combine(folder, "Contoso.Shop.Orders.Api")), Is.True);
        Assert.That(Directory.Exists(Path.Combine(folder, "Contoso.Shop.Orders.CoreService")), Is.True);
        Assert.That(File.Exists(Path.Combine(folder, "Contoso.Shop.Orders.slnx")), Is.True);
        Assert.That(File.Exists(Path.Combine(folder, "Contoso.Shop.Orders.Infrastructure", "DataAccess", "OrdersDbContext.cs")), Is.True);
    }
}
