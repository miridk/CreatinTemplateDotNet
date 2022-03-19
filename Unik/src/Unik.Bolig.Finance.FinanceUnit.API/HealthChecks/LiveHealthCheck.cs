using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Unik.Bolig.Finance.FinanceUnit.API.HealthChecks
{
    public class LiveHealthCheck : IHealthCheck
    {
        private readonly ILogger<LiveHealthCheck> logger;

        public LiveHealthCheck(ILogger<LiveHealthCheck> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthy = false;
            logger.LogTrace("test");
            isHealthy = true;

            return (isHealthy ?
                Task.FromResult(HealthCheckResult.Healthy("A healthy result."))
                : Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result.")));
        }
    }
}
