using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using ArithmeticStrategyOperation.Interfaces;

namespace ArithmeticStrategyOperation.Services
{
    public class SumParsingStrategy : IParsingStrategy
    {
        private readonly ILogger<SumParsingStrategy> _logger;
        private readonly IFileProvider _fileProvider;

        public SumParsingStrategy(ILogger<SumParsingStrategy> logger, IFileProvider fileProvider)
        {
            _logger = logger;
            _fileProvider = fileProvider;
        }

        public async Task<double> ParseNumbers()
        {
            IFileInfo fileInfo = _fileProvider.GetFileInfo(Constant.FileName);

            using Stream stream = fileInfo.CreateReadStream();
            using StreamReader reader = new StreamReader(stream);

            string fileContent = await reader.ReadToEndAsync();
            string[] values = fileContent.Split(Constant.StringSeperator, StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;

            Parallel.ForEach(values, value =>
            {
                if (int.TryParse(value, out int parsedNumber))
                {
                    Interlocked.Add(ref sum, parsedNumber);
                }
                else
                {
                    _logger.LogWarning("Error parsing number {0}", value);
                }
            });

            return sum;
        }
    }
}
