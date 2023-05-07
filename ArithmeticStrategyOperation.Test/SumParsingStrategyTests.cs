using System.Text;
using Moq;
using Xunit;
using Shouldly;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using ArithmeticStrategyOperation.Services;

namespace ArithmeticStrategyOperation.Test
{
    public class SumParsingStrategyTests
    {
        private readonly Mock<ILogger<SumParsingStrategy>> _mockLogger;
        private readonly Mock<IFileProvider> _mockFileProvider;

        public SumParsingStrategyTests()
        {
            _mockLogger = new Mock<ILogger<SumParsingStrategy>>();
            _mockFileProvider = new Mock<IFileProvider>();
        }

        [Fact]
        public async Task ParseNumbers_ShouldReturnZero_WhenFileIsEmpty()
        {
            // Arrange
            const string emptyFileContent = "";
            byte[] emptyFileBytes = Encoding.UTF8.GetBytes(emptyFileContent);
            var mockFileInfo = new Mock<IFileInfo>();

            mockFileInfo.Setup(x => x.CreateReadStream())
                .Returns(new MemoryStream(emptyFileBytes));
            _mockFileProvider.Setup(x => x.GetFileInfo(Constant.FileName))
                .Returns(mockFileInfo.Object);

            var strategy = new SumParsingStrategy(_mockLogger.Object, _mockFileProvider.Object);

            // Act
            double result = await strategy.ParseNumbers();

            // Assert
            result.ShouldBe(0);
        }

        [Fact]
        public async Task ParseNumbers_ShouldReturnSum_WhenFileContainsNumbers()
        {
            // Arrange
            const string fileContent = "1,2,3,4,5";
            byte[] fileBytes = Encoding.UTF8.GetBytes(fileContent);
            var mockFileInfo = new Mock<IFileInfo>();
            mockFileInfo.Setup(x => x.CreateReadStream())
                .Returns(new MemoryStream(fileBytes));
            _mockFileProvider.Setup(x => x.GetFileInfo(Constant.FileName))
                .Returns(mockFileInfo.Object);

            var strategy = new SumParsingStrategy(_mockLogger.Object, _mockFileProvider.Object);

            // Act
            double result = await strategy.ParseNumbers();

            // Assert
            result.ShouldBe(15);
        }

        [Fact]
        public async Task ParseNumbers_ShouldLogWarning_WhenFileContainsNonNumbers()
        {
            // Arrange
            const string fileContent = "1,2,A,3,B,5,C";
            byte[] fileBytes = Encoding.UTF8.GetBytes(fileContent);
            var mockFileInfo = new Mock<IFileInfo>();
            mockFileInfo.Setup(x => x.CreateReadStream())
                .Returns(new MemoryStream(fileBytes));
            _mockFileProvider.Setup(x => x.GetFileInfo(Constant.FileName))
                .Returns(mockFileInfo.Object);

            var strategy = new SumParsingStrategy(_mockLogger.Object, _mockFileProvider.Object);

            // Act
            double result = await strategy.ParseNumbers();

            // Assert
            result.ShouldBe(11);

            _mockLogger.Verify(x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((object v, Type _) => v.ToString().Contains("Error parsing number")),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()), Times.Exactly(3));
        }
    }
}