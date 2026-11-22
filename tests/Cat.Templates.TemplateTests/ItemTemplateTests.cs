namespace Cat.Templates.TemplateTests;

/// <summary>
/// Creates a service with <c>cat-service</c>, adds one of every item template to it, builds it and runs its tests.
/// The tests need the packs that Cake makes, so they are skipped when the environment variables are missing.
/// Run them with <c>dotnet cake --target=TemplateTest</c>.
/// </summary>
[TestFixture]
public class ItemTemplateTests
{
    // The service names are made from this prefix and the options, so every service has its own folder.
    private const string ServicePrefix = "Contoso.Shop.Orders";

    private TemplateRunner _runner = null!;

    [OneTimeSetUp]
    public async Task InstallThePack()
    {
        if (string.IsNullOrWhiteSpace(TemplateRunner.PackPath) || string.IsNullOrWhiteSpace(TemplateRunner.PackageFeed))
        {
            Assert.Ignore("CAT_TEMPLATE_PACK and CAT_PACKAGE_FEED are not set. Run dotnet cake --target=TemplateTest.");
        }

        var root = Path.Combine(Path.GetTempPath(), "cat-item-tests-" + Guid.NewGuid().ToString("N")[..8]);
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

    [TestCase("SqlServer", "CodeFirst", true, TestName = "Items_OnAServiceWithTests_ShouldBuildAndPass_SqlServer")]
    [TestCase("PostgreSQL", "DatabaseFirst", true, TestName = "Items_OnAServiceWithTests_ShouldBuildAndPass_PostgreSQLDatabaseFirst")]
    [TestCase("SqlServer", "CodeFirst", false, TestName = "Items_OnAServiceWithoutTests_ShouldBuild")]
    public async Task Items_ShouldBuildAndPassTheirTests(string database, string approach, bool tests)
    {
        var folder = await _runner.CreateServiceAsync(
            $"{ServicePrefix}{database[..2]}{approach[..1]}{(tests ? "T" : "N")}",
            $"--Database {database} --Approach {approach} --Tests {tests.ToString().ToLowerInvariant()}");
        var service = Path.GetFileName(folder);
        var flag = tests ? string.Empty : "--Tests false";

        await _runner.RunItemAsync(folder, "cat-service-request", "OrderPlace", service, flag);
        await _runner.RunItemAsync(folder, "cat-command", "OrderPlace", service);
        await _runner.RunItemAsync(folder, "cat-query", "OrderGet", service);
        await _runner.RunItemAsync(folder, "cat-validator", "OrderPlaceRequest", service, flag);
        await _runner.RunItemAsync(folder, "cat-error-definitions", "Order", service, $"--Prefix SVC-ORD {flag}");

        // A build alone would pass when a template wrote nothing, so check the files of the templates.
        string[] files =
        [
            $"{service}.Contracts/ServiceRequests/OrderPlaceRequest.cs",
            $"{service}.CoreService/ServiceRequestHandlers/OrderPlaceRequestHandler.cs",
            $"{service}.CoreService/Commands/OrderPlaceCommand.cs",
            $"{service}.Infrastructure/CommandHandlers/OrderPlaceCommandHandler.cs",
            $"{service}.CoreService/Queries/OrderGetQuery.cs",
            $"{service}.Infrastructure/QueryHandlers/OrderGetQueryHandler.cs",
            $"{service}.CoreService/Validators/OrderPlaceRequestValidator.cs",
            $"{service}.CoreService/OrderErrorDefinitions.cs"
        ];
        foreach (var file in files)
        {
            Assert.That(File.Exists(Path.Combine(folder, file)), Is.True, file);
        }

        var build = await _runner.DotnetAsync("build --nologo", folder);
        Assert.That(build.ExitCode, Is.EqualTo(0), build.Output);

        if (tests)
        {
            var test = await _runner.DotnetAsync("test --no-build --nologo", folder);
            Assert.That(test.ExitCode, Is.EqualTo(0), test.Output);
        }
    }
}
