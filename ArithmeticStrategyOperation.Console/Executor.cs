using Serilog;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Console
{
    internal class Executor
    {
        private readonly IParsingStrategy parsingStrategy;
        private readonly IWriteOutputStrategy writeOutputStrategy;

        public Executor(IParsingStrategy parsingStrategy, IWriteOutputStrategy writeOutputStrategy)
        {
            this.parsingStrategy = parsingStrategy;
            this.writeOutputStrategy = writeOutputStrategy;
        }

        public async Task Execute()
        {
            try
            {
                Log.Information("Parsing numbers from file {0}", Constant.FileName);

                double result = await parsingStrategy.ParseNumbers();
                await writeOutputStrategy.Write($"Sum of numbers: {result}");

                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }
    }
}
