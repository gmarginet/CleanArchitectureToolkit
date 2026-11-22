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
    [TestCase("SqlServer", "DatabaseFirst", true, TestName = "Items_OnAServiceWithTests_ShouldBuildAndPass_SqlServerDatabaseFirst")]
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

        // These items need the package of their module in the core project, and the event item in the test project too.
        await _runner.AddCatPackageAsync(folder, $"{service}.CoreService", "gmarginet.Cat.FluentWorkflows");
        await _runner.AddCatPackageAsync(folder, $"{service}.CoreService", "gmarginet.Cat.EventAggregators.Abstractions");
        await _runner.AddCatPackageAsync(folder, $"{service}.CoreService", "gmarginet.Cat.Decorators.Abstractions");
        if (tests)
        {
            await _runner.AddCatPackageAsync(folder, $"{service}.CoreService.Tests", "gmarginet.Cat.UnitTesting.EventAggregators");
        }

        // The Dapper items need the module, the generator of the SQL constants and the line that lets it see the .sql files.
        await _runner.AddCatPackageAsync(folder, $"{service}.Infrastructure", "gmarginet.Cat.Dapper");
        await _runner.AddCatPackageAsync(folder, $"{service}.Infrastructure", "gmarginet.Cat.Dapper.SqlFiles");
        var infrastructureProject = Path.Combine(folder, $"{service}.Infrastructure", $"{service}.Infrastructure.csproj");
        var projectText = await File.ReadAllTextAsync(infrastructureProject);
        await File.WriteAllTextAsync(
            infrastructureProject,
            projectText.Replace("</Project>", "  <ItemGroup>\n    <AdditionalFiles Include=\"**/*.sql\" />\n  </ItemGroup>\n\n</Project>"));

        var databaseName = database == "PostgreSQL" ? "PostgreSQL" : "SqlServer";
        await _runner.RunItemAsync(folder, "cat-entity", "Product", service, $"--Database {databaseName}");
        await _runner.RunItemAsync(folder, "cat-dapper-query", "OrderOverview", service);
        await _runner.RunItemAsync(folder, "cat-dapper-command", "OrderCancel", service);
        if (approach == "DatabaseFirst")
        {
            await _runner.RunItemAsync(folder, "cat-table", "Product", service, $"--Database {databaseName}");
        }

        // The messaging items need the abstractions in the Contracts and the core project, the saga needs its module and its fake.
        await _runner.AddCatPackageAsync(folder, $"{service}.Contracts", "gmarginet.Cat.Messaging.Abstractions");
        await _runner.AddCatPackageAsync(folder, $"{service}.CoreService", "gmarginet.Cat.Messaging.Abstractions");
        await _runner.AddCatPackageAsync(folder, $"{service}.CoreService", "gmarginet.Cat.Sagas");
        if (tests)
        {
            await _runner.AddCatPackageAsync(folder, $"{service}.CoreService.Tests", "gmarginet.Cat.UnitTesting.Messaging");
        }

        await _runner.RunItemAsync(folder, "cat-message", "OrderShipped", service);
        await _runner.RunItemAsync(folder, "cat-message", "ShipOrder", service, "--Kind Command");
        await _runner.RunItemAsync(folder, "cat-message-handler", "OrderShipped", service, flag);
        await _runner.RunItemAsync(folder, "cat-saga", "OrderPay", service, flag);

        // The project templates write a project folder. The developer adds it to the solution and gives it its package.
        await _runner.RunProjectTemplateAsync(folder, "cat-api-client", service);
        await _runner.AddProjectToSolutionAsync(folder, service, $"{service}.Api.Client");
        // The client project already has its package version in Directory.Packages.Cat.props. The gateway needs one.
        await _runner.RunProjectTemplateAsync(folder, "cat-gateway", service);
        await _runner.AddProjectToSolutionAsync(folder, service, $"{service}.Api.Gateway");
        var packagesFile = Path.Combine(folder, "Directory.Packages.Cat.props");
        var packagesText = await File.ReadAllTextAsync(packagesFile);
        await File.WriteAllTextAsync(
            packagesFile,
            packagesText.Replace("</ItemGroup>", "    <PackageVersion Include=\"gmarginet.Cat.Api.Gateway\" Version=\"$(CatVersion)\" />\n  </ItemGroup>"));

        await _runner.RunItemAsync(folder, "cat-workflow", "OrderFlow", service, flag);
        await _runner.RunItemAsync(folder, "cat-event", "OrderPlaced", service, flag);
        await _runner.RunItemAsync(folder, "cat-decorator", "AuditCommands", service, $"--For Command {flag}");
        await _runner.RunItemAsync(folder, "cat-decorator", "AuditQueries", service, $"--For Query {flag}");
        await _runner.RunItemAsync(folder, "cat-decorator", "AuditRequests", service, $"--For ServiceRequest {flag}");

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
            $"{service}.CoreService/OrderErrorDefinitions.cs",
            $"{service}.CoreService/Workflows/OrderFlowWorkflow.cs",
            $"{service}.CoreService/Workflows/OrderFlowState.cs",
            $"{service}.CoreService/Events/OrderPlacedEvent.cs",
            $"{service}.CoreService/EventSubscribers/OrderPlacedSubscriber.cs",
            $"{service}.CoreService/Decorators/AuditCommandsDecorator.cs",
            $"{service}.CoreService/Decorators/AuditQueriesDecorator.cs",
            $"{service}.CoreService/Decorators/AuditRequestsDecorator.cs",
            $"{service}.DataModels/Entities/Product.cs",
            $"{service}.Infrastructure/DataAccess/ProductModelBuilderExtensions.cs",
            $"{service}.Infrastructure/QueryHandlers/OrderOverviewQueryHandler.sql",
            $"{service}.Infrastructure/CommandHandlers/OrderCancelCommandHandler.sql",
            $"{service}.Contracts/Messages/OrderShipped.cs",
            $"{service}.Contracts/Messages/ShipOrder.cs",
            $"{service}.CoreService/ServiceRequestHandlers/OrderShippedHandler.cs",
            $"{service}.CoreService/Workflows/OrderPaySaga.cs",
            $"{service}.CoreService/Messages/OrderPayRequested.cs",
            $"{service}.Api.Client/{service}.Api.Client.csproj",
            $"{service}.Api.Gateway/Program.cs"
        ];
        if (approach == "DatabaseFirst")
        {
            files = [.. files, database == "PostgreSQL" ? $"{service}.Database/Scripts/Product.sql" : $"{service}.Database/Tables/Product.sql"];
        }
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
