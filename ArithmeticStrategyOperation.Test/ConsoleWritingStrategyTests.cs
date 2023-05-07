using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using ArithmeticStrategyOperation.Services;

namespace ArithmeticStrategyOperation.Test
{
    public class ConsoleWritingStrategyTests
    {
        private readonly Mock<ILogger<ConsoleWritingStrategy>> mockLogger;

        public ConsoleWritingStrategyTests()
        {
            mockLogger = new Mock<ILogger<ConsoleWritingStrategy>>();
        }

        [Fact]
        public async Task Write_ShouldLogInformation_WithResultToString()
        {
            // Arrange
            const string expectedResult = "Sum of numbers: 30";
            var strategy = new ConsoleWritingStrategy(mockLogger.Object);

            // Act
            await strategy.Write(expectedResult);

            // Assert
            mockLogger.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v.ToString().Contains(expectedResult)),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
        }
    }
}
