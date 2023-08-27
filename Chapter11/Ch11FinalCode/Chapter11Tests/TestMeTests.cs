using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Packt.CloudySkiesAir.Chapter11.Tests
{
    public class TestMeTests
    {
        [Fact]
        public void CalculateLargestNumberWithoutASeven_ThrowsException_WhenInputIsNull()
        {
            // Arrange
            Mock<INumberProvider> mockProvider = new Mock<INumberProvider>();
            mockProvider.Setup(x => x.GenerateNumbers()).Returns((IEnumerable<int>)null);

            // Act & Assert            
            Assert.Throws<ArgumentNullException>(() => TestMe.CalculateLargestNumberWithoutASeven(mockProvider.Object));
        }

        [Fact]
        public void CalculateLargestNumberWithoutASeven_ReturnsLargestNumberWithoutSeven_WhenInputIsValid()
        {
            // Arrange
            Mock<INumberProvider> mockProvider = new Mock<INumberProvider>();
            mockProvider.Setup(x => x.GenerateNumbers()).Returns(new List<int> { 17, 2, 13, 4, 22, 44 });

            // Act
            int result = TestMe.CalculateLargestNumberWithoutASeven(mockProvider.Object);

            // Assert
            Assert.Equal(44, result);
        }
    }
}
