using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleAPI.HealthChecks
{
    public class DegradedHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                HealthCheckResult.Degraded("The check indicates a degraded state."));
        }
    }
}
