namespace Packt.CloudySkiesAir.Chapter2.Tests;

public class BaggageCalculatorTests
{
    [Fact]
    public void PriceWithNoBagsIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 1;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(100, actualPrice);
    }

    [Fact]
    public void PriceWithTwoPassengersAndThreeCheckedIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 2;
        int numPassengers = 2;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(195, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 1;
        int numPassengers = 1;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(110, actualPrice);
    }

    [Fact]
    public void PriceWithTwoCheckedIsCorrect()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 2;
        int numCarryOn = 1;
        int numPassengers = 1;
        
        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(160, actualPrice);
    }
}