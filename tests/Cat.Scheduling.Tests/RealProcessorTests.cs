using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.Scheduling.Abstractions;
using Cat.Scheduling.Extensions;
using Cat.ServiceRequests.Abstractions;
using Cat.ServiceRequests.Extensions;
using Cat.Users.Abstractions;
using Cat.Users.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Cat.Scheduling.Tests;

/// <summary>
/// Runs a job through the real service request processor and the real user module, to see what a handler gets.
/// </summary>
[TestFixture]
public class RealProcessorTests
{
    public static readonly List<(bool IsAuthenticated, string UserId, bool InRole)> Seen = new List<(bool, string, bool)>();

    public record WhoAmIRequest : ICatServiceRequest;

    public class WhoAmIHandler : ICatServiceRequestHandler<WhoAmIRequest>
    {
        private readonly ICatUser _user;

        public WhoAmIHandler(ICatUser user)
        {
            _user = user;
        }

        public Task<ICatResponse> HandleAsync(WhoAmIRequest serviceRequest, CancellationToken cancellationToken = default)
        {
            lock (Seen)
            {
                Seen.Add((_user.IsAuthenticated, _user.UserId, _user.IsInRole("system")));
            }

            return Task.FromResult(CatResponse.Ok());
        }
    }

    [Test]
    public async Task Job_TheHandlerSeesTheSystemUser()
    {
        lock (Seen) { Seen.Clear(); }
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddLogging();
        services.AddHttpContextAccessor();
        services.AddCatUsers();
        services.AddCatServiceRequestsModule(typeof(WhoAmIHandler));
        services.AddCatScheduling(TestHost.Configuration(), builder => builder.RunAs("orders").Job<WhoAmIRequest>("who", "5 0 * * *"));
        using var provider = services.BuildServiceProvider();

        var result = await provider.GetRequiredService<ICatJobRunner>().RunAsync("who");

        Assert.That(result.Status, Is.EqualTo(CatJobRunStatus.Succeeded));
        lock (Seen)
        {
            Assert.That(Seen.Single(), Is.EqualTo((true, "orders", true)));
        }
    }
}
