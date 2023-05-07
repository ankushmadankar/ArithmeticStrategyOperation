using Serilog;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Console
{
    internal class Executor
    {
        private readonly IParsingStrategy _parsingStrategy;
        private readonly IWriteOutputStrategy _writeOutputStrategy;

        public Executor(IParsingStrategy parsingStrategy, IWriteOutputStrategy writeOutputStrategy)
        {
            _parsingStrategy = parsingStrategy;
            _writeOutputStrategy = writeOutputStrategy;
        }

        public async Task Execute()
        {
            try
            {
                Log.Information("Parsing numbers from file {0}", Constant.FileName);

                double result = await _parsingStrategy.ParseNumbers();
                await _writeOutputStrategy.Write($"Sum of numbers: {result}");

                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}
