using Microsoft.Extensions.Logging;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Services
{
    public class ConsoleWritingStrategy : IWriteOutputStrategy
    {
        private readonly ILogger<ConsoleWritingStrategy> _logger;

        public ConsoleWritingStrategy(ILogger<ConsoleWritingStrategy> logger)
        {
            _logger = logger;
        }

        public async Task Write<TResult>(TResult result)
        {
            _logger.LogInformation($"{result}");
            await Task.CompletedTask;
        }
    }
}
