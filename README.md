# ArithmeticStrategyOperation

Problem Statement: Given.

Solution:
To meet requirements, we can follow the SOLID principles and use a design pattern like the Strategy pattern.

The Strategy pattern allows us to define a family of algorithms, encapsulate each one as an object, and make them interchangeable. This way, we can easily add or replace algorithms without changing the core logic of the application.

- `IParsingStrategy`: Interface will provide contract to follow the how parsing will done on input provided. Parse numbers with required strategy e.g. Sum, Multiplication
- `IWriteOutputStrategy`: Interface will provide contract how to write the output. Contract will allow type to write output with different source like Console, File, Message Queue or Email

__How to Run__

- This project build on dotnet 6, runtime can be install from here - https://dotnet.microsoft.com/en-us/download/dotnet/6.0
- If project run from Visual Studio then Visual Studio 2022 will be required.
- Project can be run also using this VS command (Navigate to directory ./ArithmeticStrategyOperation.Console):
>>dotnet run ArithmeticStrategyOperation.csproj
