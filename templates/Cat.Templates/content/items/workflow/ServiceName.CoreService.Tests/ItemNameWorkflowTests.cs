using Cat.FluentWorkflows.Abstractions;
using Cat.FluentWorkflows.Extensions;
using Cat.UnitTesting.NUnit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ServiceName.CoreService.Workflows;

namespace ServiceName.CoreService.Tests;

[TestFixture]
public class ItemNameWorkflowTests : UnitTestBase
{
    // Fully qualified, because a project that references the Api project sees a second ServiceCollection type.
    protected override void ConfigureServices(Microsoft.Extensions.DependencyInjection.ServiceCollection services)
    {
        // Every step gets a logger. A test needs none that writes.
        services.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
        services.AddCatFluentWorkflowsModule();
        services.AddCatFluentWorkflowsFlows(typeof(ItemNameWorkflow));
    }

    [Test]
    public async Task Run_ShouldFinishWithoutErrors()
    {
        var processor = ServiceProvider.GetRequiredService<ICatWorkflowProcessor>();
        var state = new ItemNameState();

        var response = await processor.RunAsync<ItemNameWorkflow, ItemNameState>(state, CancellationToken.None);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(response.ErrorList, Is.Empty);
            Assert.That(state.Done, Is.True);
        }
    }
}
