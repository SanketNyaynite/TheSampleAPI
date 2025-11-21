using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TheSampleAPI.HealthChecks
{
    public class RandomHealthCheck : IHealthCheck   
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            int randomResult = Random.Shared.Next(1, 4);

            return randomResult switch
            {
                1 => Task.FromResult(
                    HealthCheckResult.Healthy("The check indicates a healthy state.")),
                2 => Task.FromResult(
                    HealthCheckResult.Degraded("The check indicates a degraded state.")),
                3 => Task.FromResult(
                    HealthCheckResult.Unhealthy("The check indicates an unhealthy state.")),
                _ => Task.FromResult(
                    HealthCheckResult.Healthy("The check indicates an unhealthy state.")),
            };
        }
    }
}
