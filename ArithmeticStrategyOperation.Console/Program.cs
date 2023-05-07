using Serilog;
using ArithmeticStrategyOperation;
using ArithmeticStrategyOperation.Services;
using ArithmeticStrategyOperation.Interfaces;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .CreateLogger();

IWriteOutputStrategy writeOutputStrategy = new ConsoleWritingStrategy();
IParsingStrategy parsingStrategy = new SumParsingStrategy();

Log.Information("Parsing numbers from file {0}", Constant.FileName);

double result = await parsingStrategy.ParseNumbers();
await writeOutputStrategy.Write($"Sum of numbers: {result}");

Console.ReadKey();