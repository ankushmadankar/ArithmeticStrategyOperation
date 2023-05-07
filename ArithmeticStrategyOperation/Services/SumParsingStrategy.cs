using Serilog;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Services
{
    public class SumParsingStrategy : IParsingStrategy
    {
        public async Task<double> ParseNumbers()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, Constant.FileName);
            string fileContent = await File.ReadAllTextAsync(filePath);

            string[] values = fileContent.Split(Constant.StringSeperator, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            Parallel.ForEach(values, value =>
            {
                if (int.TryParse(value, out int parsedNumber))
                {
                    sum += parsedNumber;
                }
                else
                {
                    Log.Warning("Error parsing number {0}", value);
                }
            });

            return sum;
        }
    }
}
