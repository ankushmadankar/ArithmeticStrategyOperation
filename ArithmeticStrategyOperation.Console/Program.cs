using Serilog;
using ArithmeticStrategyOperation.Services;
using ArithmeticStrategyOperation.Interfaces;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using ArithmeticStrategyOperation.Console;

Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .CreateLogger();

var services = new ServiceCollection();
ConfigureServices(services);

await services
    .BuildServiceProvider()
    .GetService<Executor>()
    .Execute();

static void ConfigureServices(IServiceCollection services)
{
    services.AddLogging(builder => builder.AddSerilog());

    var fileProvider = new PhysicalFileProvider(AppContext.BaseDirectory);
    services.AddSingleton<IFileProvider>(fileProvider);

    services.AddSingleton<Executor>();
    services.AddTransient<IParsingStrategy, SumParsingStrategy>();
    services.AddTransient<IWriteOutputStrategy, ConsoleWritingStrategy>();
}