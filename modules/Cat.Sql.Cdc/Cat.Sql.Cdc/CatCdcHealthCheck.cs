using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Cat.Sql.Cdc;

internal sealed class CatCdcHealthCheck : IHealthCheck
{
    private readonly CatCdcStatus _status;

    public CatCdcHealthCheck(CatCdcStatus status)
    {
        _status = status;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        if (_status.Stopped > 0)
        {
            return Task.FromResult(HealthCheckResult.Unhealthy($"A table stopped reading. {_status.StoppedDescription}"));
        }

        if (_status.Failing > 0)
        {
            return Task.FromResult(HealthCheckResult.Degraded($"The last poll of a table failed. {_status.FailingDescription}"));
        }

        return Task.FromResult(HealthCheckResult.Healthy("The change readers are running."));
    }
}
