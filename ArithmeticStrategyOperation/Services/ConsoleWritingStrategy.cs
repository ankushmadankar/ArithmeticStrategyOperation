using ArithmeticStrategyOperation.Interfaces;
using Serilog;

namespace ArithmeticStrategyOperation.Services
{
    public class ConsoleWritingStrategy : IWriteOutputStrategy
    {
        private readonly string outputStringFormat;
        public ConsoleWritingStrategy(string outputStringFormat)
        {
            this.outputStringFormat = outputStringFormat;
        }

        public ConsoleWritingStrategy() : this("{0}")
        {
        }

        public async Task Write<TResult>(TResult result)
        {
            Log.Information(outputStringFormat, result);
            await Task.CompletedTask;
        }
    }
}
