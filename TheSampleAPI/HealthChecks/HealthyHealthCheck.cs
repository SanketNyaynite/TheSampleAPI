using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleAPI.HealthChecks
{
    public class HealthyHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("The check indicates a healthy state."));
        }
    }
}
