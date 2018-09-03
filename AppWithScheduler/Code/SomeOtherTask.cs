using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace AppWithScheduler.Code
{
    public class SomeOtherTask : IScheduledTask
    {
        public string Schedule => "*/1 * * * *";

        private readonly IServiceScopeFactory scopeFactory;

        public SomeOtherTask(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<IScheduledTask>();
            }
            await Task.CompletedTask;
        }
    }
}