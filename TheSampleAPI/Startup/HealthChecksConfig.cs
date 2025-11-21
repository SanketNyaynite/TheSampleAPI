
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using TheSampleAPI.HealthChecks;

namespace TheSampleAPI.Startup
{
    public static class HealthChecksConfigiesConfig
    {
         public static void AddAllHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddCheck<RandomHealthCheck>("Random", tags: ["random"])
                .AddCheck<HealthyHealthCheck>("Healthy", tags: ["healthy"])
                .AddCheck<DegradedHealthCheck>("Degraded", tags: ["degraded"])
                .AddCheck<UnhealthyHealthCheck>("Unhealthy", tags: ["unhealthy"]);
        }

        public static void MapAllHealthChecks(this WebApplication app)
        {
            app.MapHealthChecks("/health/random", new()
            {
                Predicate = check => check.Tags.Contains("random")
            });
            app.MapHealthChecks("/health/healthy", new()
            {
                Predicate = check => check.Tags.Contains("healthy")
            });
            app.MapHealthChecks("/health/degraded", new()
            {
                Predicate = check => check.Tags.Contains("degraded")
            });
            app.MapHealthChecks("/health/unhealthy", new()
            {
                Predicate = check => check.Tags.Contains("unhealthy")
            });

            app.MapHealthChecks("/health/ui", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.MapHealthChecks("/health/ui/random", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("random"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/healthy", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("healthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/degraded", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("degraded"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.MapHealthChecks("/health/ui/unhealthy", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("unhealthy"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
