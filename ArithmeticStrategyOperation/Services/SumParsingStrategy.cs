using ArithmeticStrategyOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticStrategyOperation.Services
{
    public class SumParsingStrategy : IParsingStrategy
    {
        private readonly IWriteOutputStrategy writeOutputStrategy;

        public SumParsingStrategy(IWriteOutputStrategy writeOutputStrategy)
        {
            this.writeOutputStrategy = writeOutputStrategy;
        }

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
                    writeOutputStrategy.Write(string.Format("Error parsing number {0}", value));
                }
            });

            return sum;
        }
    }
}
