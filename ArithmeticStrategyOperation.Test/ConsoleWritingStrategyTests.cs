using Moq;
using Xunit;
using Microsoft.Extensions.Logging;
using ArithmeticStrategyOperation.Services;

namespace ArithmeticStrategyOperation.Test
{
    public class ConsoleWritingStrategyTests
    {
        private readonly Mock<ILogger<ConsoleWritingStrategy>> _mockLogger;

        public ConsoleWritingStrategyTests()
        {
            _mockLogger = new Mock<ILogger<ConsoleWritingStrategy>>();
        }

        [Fact]
        public async Task WriteOutput_ShouldLogInformation_WithStringResult()
        {
            // Arrange
            const string expectedResult = "Sum of numbers: 30";
            var strategy = new ConsoleWritingStrategy(_mockLogger.Object);

            // Act
            await strategy.Write(expectedResult);

            // Assert
            _mockLogger.Verify(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v.ToString().Contains(expectedResult)),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Once);
        }
    }
}
