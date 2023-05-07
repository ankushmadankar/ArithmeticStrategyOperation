using Microsoft.Extensions.Logging;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Services
{
    public class ConsoleWritingStrategy : IWriteOutputStrategy
    {
        private readonly ILogger<ConsoleWritingStrategy> logger;

        public ConsoleWritingStrategy(ILogger<ConsoleWritingStrategy> logger)
        {
            this.logger = logger;
        }

        public async Task Write<TResult>(TResult result)
        {
            logger.LogInformation($"{result}");
            await Task.CompletedTask;
        }
    }
}
