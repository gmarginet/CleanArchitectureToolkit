using Azure.Messaging.ServiceBus;
using Cat.EventProcessor.Abstractions;
using Cat.EventProcessor.Authorization;
using Cat.EventProcessor.Authorization.Extensions;
using Cat.EventProcessor.AzureServiceBus;
using Cat.EventProcessor.Extensions;
using Cat.Messaging.Abstractions;
using Cat.Responses;
using Cat.Responses.Abstractions;
using Cat.ServiceRequests.Abstractions;
using Cat.Users.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Cat.EventProcessor.Tests;

[TestFixture]
public class AuthorizationTests
{
    private const string Issuer = "https://issuer.test";
    private const string Audience = "cat-gateway";

    private static readonly SymmetricSecurityKey SigningKey = new(new byte[32].Select((_, i) => (byte)(i + 1)).ToArray());
    private static readonly SymmetricSecurityKey OtherKey = new(new byte[32].Select((_, i) => (byte)(i + 100)).ToArray());

    private SeenProcessor _processor = null!;
    private FakeStore _store = null!;

    [SetUp]
    public void SetUp()
    {
        _processor = new SeenProcessor();
        _store = new FakeStore();
    }

    private static string TokenOf(string[] roles, DateTime? expires = null, SecurityKey? key = null, string subject = "u-1")
    {
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = Issuer,
            Audience = Audience,
            NotBefore = (expires ?? DateTime.UtcNow.AddMinutes(10)).AddHours(-2),
            Expires = expires ?? DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(key ?? SigningKey, SecurityAlgorithms.HmacSha256),
            Claims = new Dictionary<string, object> { ["sub"] = subject, ["name"] = "Alice", ["roles"] = roles }
        };
        return new JsonWebTokenHandler().CreateToken(descriptor);
    }

    private ServiceProvider Build(Action<CatReceiveOptions>? configure, Action<CatMessageAuthorizationOptions>? authorization = null,
        bool withAuthorizer = true, bool withStore = false)
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        services.AddLogging();
        services.AddScoped<ICatServiceRequestProcessor>(provider => new SeenProcessor(_processor, provider.GetService<ICatUserAccessor>()));
        if (withStore)
        {
            services.AddScoped<ICatInboxStore>(_ => _store);
        }

        var configuration = new ConfigurationBuilder().Build();
        services.AddCatEventProcessor(configuration, builder => builder.Receive<OrderPlaced>(configure));
        if (withAuthorizer)
        {
            services.AddAuthentication().AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    IssuerSigningKey = SigningKey,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });
            services.AddAuthorization(options => options.AddPolicy("PriceAdmin", policy => policy.RequireRole("admin")));
            services.AddCatEventProcessorAuthorization(authorization);
        }

        return services.BuildServiceProvider();
    }

    private static CatIncomingMessage MessageOf(string? token, DateTimeOffset? enqueued = null, bool scheduled = false)
    {
        var message = new CatIncomingMessage
        {
            Body = Json.Of(new { orderNumber = "ORD-1" }),
            ContentType = "application/json",
            MessageId = "message-1",
            EnqueuedTime = enqueued,
            IsScheduled = scheduled
        };
        if (token != null)
        {
            message.Properties[CatMessageProperties.Authorization] = "Bearer " + token;
        }

        return message;
    }

    private static Task<CatSettlementResult> ReceiveAsync(ServiceProvider provider, CatIncomingMessage message) =>
        provider.GetRequiredService<ICatMessageReceiver>().ReceiveAsync(typeof(OrderPlaced), message);

    [Test]
    public async Task NoRule_NoToken_RunsTheHandlerAsTheAnonymousUser()
    {
        using var provider = Build(null);

        var result = await ReceiveAsync(provider, MessageOf(null));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenUser!.IsAuthenticated, Is.False);
    }

    [Test]
    public async Task NoRule_ValidToken_SetsTheUserFromTheToken()
    {
        using var provider = Build(null);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenUser!.IsAuthenticated, Is.True);
        Assert.That(_processor.SeenUser.UserId, Is.EqualTo("u-1"));
        Assert.That(_processor.SeenUser.Name, Is.EqualTo("Alice"));
        Assert.That(_processor.SeenUser.IsInRole("admin"), Is.True);
    }

    [Test]
    public async Task Policy_AnAdminPasses()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
        Assert.That(_processor.SeenRequest, Is.Not.Null);
    }

    [Test]
    public async Task Policy_CanBeSetFromTheConfiguration()
    {
        var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
        var settings = new Dictionary<string, string?> { ["CatEventProcessor:Messages:OrderPlaced:Policy"] = "PriceAdmin" };
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(settings).Build();
        services.AddCatEventProcessor(configuration, builder => builder.Receive<OrderPlaced>());

        using var provider = services.BuildServiceProvider();
        var options = provider.GetRequiredService<ICatReceiveRegistry>().Registrations.Single().Options;

        Assert.That(options.Policy, Is.EqualTo("PriceAdmin"));
        Assert.That(options.HasAuthorizationRule, Is.True);
    }

    [Test]
    public async Task Policy_ABuyerIsForbiddenAndTheMessageIsDeadLettered()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["buyer"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Forbidden"));
        Assert.That(_processor.SeenRequest, Is.Null);
    }

    [Test]
    public async Task Policy_AMessageWithoutATokenIsUnauthorized()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");

        var result = await ReceiveAsync(provider, MessageOf(null));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Unauthorized"));
        Assert.That(_processor.SeenRequest, Is.Null);
    }

    [Test]
    public async Task Token_AWrongSignatureIsUnauthorizedEvenWithoutAPolicy()
    {
        using var provider = Build(null);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"], key: OtherKey)));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Unauthorized"));
        Assert.That(_processor.SeenRequest, Is.Null);
    }

    [Test]
    public async Task Lifetime_ATokenThatWasValidWhenTheBusReceivedTheMessagePasses()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");
        var expires = DateTime.UtcNow.AddHours(-1);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"], expires), enqueued: DateTimeOffset.UtcNow.AddHours(-2)));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public async Task Lifetime_ATokenThatHadExpiredWhenTheBusReceivedTheMessageIsRejected()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");
        var expires = DateTime.UtcNow.AddHours(-1);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"], expires), enqueued: DateTimeOffset.UtcNow));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Unauthorized"));
    }

    [Test]
    public async Task Scheduled_AnExpiredTokenPassesBecauseTheLifetimeIsSkipped()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");
        var expires = DateTime.UtcNow.AddHours(-1);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"], expires), enqueued: DateTimeOffset.UtcNow, scheduled: true));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public async Task Scheduled_ASignatureThatDoesNotMatchIsStillRejected()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");
        var expires = DateTime.UtcNow.AddHours(-1);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"], expires, OtherKey), enqueued: DateTimeOffset.UtcNow, scheduled: true));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
    }

    [Test]
    public async Task Inline_ARuleOfThePolicyBuilderPasses()
    {
        using var provider = Build(options => options.Require(policy => policy.RequireRole("admin").RequireClaim("sub", "u-1")));

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public async Task Inline_ARuleThatIsNotMetIsForbidden()
    {
        using var provider = Build(options => options.Require(policy => policy.RequireRole("admin").RequireClaim("sub", "u-2")));

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Forbidden"));
    }

    [Test]
    public async Task Policy_AndAnInlineRuleMustBothPass()
    {
        using var provider = Build(options =>
        {
            options.Policy = "PriceAdmin";
            options.Require(policy => policy.RequireClaim("sub", "u-2"));
        });

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Reason, Is.EqualTo("Forbidden"));
    }

    [Test]
    public async Task Setting_DeniesAMessageTypeWithoutARuleWhenItIsOn()
    {
        using var provider = Build(null, authorization => authorization.DenyMessagesWithoutPolicy = true);

        var result = await ReceiveAsync(provider, MessageOf(TokenOf(["admin"])));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.DeadLetter));
        Assert.That(result.Reason, Is.EqualTo("Forbidden"));
    }

    [Test]
    public async Task Setting_AlwaysTrueRuleKeepsATypeOpenWhenTheSettingIsOn()
    {
        using var provider = Build(options => options.Require(policy => policy.RequireAssertion(_ => true)),
            authorization => authorization.DenyMessagesWithoutPolicy = true);

        var result = await ReceiveAsync(provider, MessageOf(null));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public async Task Order_ADeniedMessageLeavesNoRowInTheInbox()
    {
        using var provider = Build(options =>
        {
            options.Policy = "PriceAdmin";
            options.UseInbox = true;
        }, withStore: true);

        await ReceiveAsync(provider, MessageOf(TokenOf(["buyer"])));

        Assert.That(_store.Added, Is.Empty);
    }

    [Test]
    public async Task Receiver_WithoutAnAuthorizerRunsTheMessageAsBefore()
    {
        using var provider = Build(null, withAuthorizer: false);

        var result = await ReceiveAsync(provider, MessageOf(null));

        Assert.That(result.Settlement, Is.EqualTo(CatSettlement.Complete));
    }

    [Test]
    public async Task Listener_FailsAtStartupWhenAPolicyIsSetAndNoAuthorizerIsRegistered()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin", withAuthorizer: false);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => CreateListener(provider).StartAsync(CancellationToken.None));

        Assert.That(exception!.Message, Does.Contain("OrderPlaced").And.Contain("ICatMessageAuthorizer"));
    }

    [Test]
    public async Task StartupCheck_FailsForAPolicyNameThatDoesNotExist()
    {
        using var provider = Build(options => options.Policy = "Nope");

        var check = provider.GetServices<IHostedService>().Single(service => service is AuthorizationStartupCheck);
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => check.StartAsync(CancellationToken.None));

        Assert.That(exception!.Message, Does.Contain("Nope").And.Contain("OrderPlaced"));
    }

    [Test]
    public async Task StartupCheck_PassesForAPolicyThatExists()
    {
        using var provider = Build(options => options.Policy = "PriceAdmin");

        var check = provider.GetServices<IHostedService>().Single(service => service is AuthorizationStartupCheck);

        Assert.That(async () => await check.StartAsync(CancellationToken.None), Throws.Nothing);
    }

    [Test]
    public void Mapper_ReadsTheArrivalTimeAndTheScheduledFlag()
    {
        var enqueued = DateTimeOffset.UtcNow;
        var scheduled = ServiceBusModelFactory.ServiceBusReceivedMessage(body: BinaryData.FromString("{}"), messageId: "m",
            enqueuedTime: enqueued, scheduledEnqueueTime: enqueued);
        var immediate = ServiceBusModelFactory.ServiceBusReceivedMessage(body: BinaryData.FromString("{}"), messageId: "m", enqueuedTime: enqueued);

        var mappedScheduled = ServiceBusIncomingMessageMapper.ToIncomingMessage(scheduled);
        var mappedImmediate = ServiceBusIncomingMessageMapper.ToIncomingMessage(immediate);

        Assert.That(mappedScheduled.IsScheduled, Is.True);
        Assert.That(mappedScheduled.EnqueuedTime, Is.EqualTo(enqueued));
        Assert.That(mappedImmediate.IsScheduled, Is.False);
    }

    private static ServiceBusListener CreateListener(ServiceProvider provider) => new(
        new ServiceBusClient("Endpoint=sb://unused.servicebus.windows.net/;SharedAccessKeyName=a;SharedAccessKey=YQ=="),
        provider.GetRequiredService<ICatReceiveRegistry>(), null!, provider.GetRequiredService<ICatMessageReceiver>(),
        Options.Create(new CatEventProcessorServiceBusOptions()), new ListenerStatus(), NullLogger<ServiceBusListener>.Instance,
        provider.GetRequiredService<IServiceProviderIsService>());

    private sealed class FakeStore : ICatInboxStore
    {
        public List<(string Id, string Type)> Added { get; } = new();

        public Task<bool> ExistsAsync(string messageId, CancellationToken cancellationToken = default) => Task.FromResult(false);

        public void Add(string messageId, string messageType) => Added.Add((messageId, messageType));
    }

    /// <summary>
    /// Remembers the request and the user that were current when the handler ran. The scoped copy reports to the shared one.
    /// </summary>
    private sealed class SeenProcessor : ICatServiceRequestProcessor
    {
        private readonly SeenProcessor? _shared;
        private readonly ICatUserAccessor? _accessor;

        public SeenProcessor()
        {
        }

        public SeenProcessor(SeenProcessor shared, ICatUserAccessor? accessor)
        {
            _shared = shared;
            _accessor = accessor;
        }

        public ICatServiceRequest? SeenRequest { get; private set; }
        public ICatUser? SeenUser { get; private set; }

        public Task<ICatResponse> ProcessAsync(ICatServiceRequest catServiceRequest, CancellationToken cancellationToken = default)
        {
            _shared!.SeenRequest = catServiceRequest;
            _shared.SeenUser = _accessor?.User;
            return Task.FromResult(CatResponse.Ok());
        }

        public Task<ICatResponse<TResponse>> ProcessAsync<TResponse>(ICatServiceRequest<TResponse> catServiceRequest, CancellationToken cancellationToken = default)
            => throw new NotSupportedException();

        public ICatResponse Process(ICatServiceRequest catServiceRequest) => throw new NotSupportedException();

        public ICatResponse<TResponse> Process<TResponse>(ICatServiceRequest<TResponse> catServiceRequest) => throw new NotSupportedException();
    }
}
