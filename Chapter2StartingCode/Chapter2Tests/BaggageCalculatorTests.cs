namespace Packt.CloudySkiesAir.Chapter2.Tests;

public class BaggageCalculatorTests
{
    [Fact]
    public void PriceWithSinglePassengerNoBagsReturnsBasePrice()
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
    public void PriceWithMultiplePassengersNoBagsReturnsBasePricePlusExtraPassengerDiscount()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 0;
        int numPassengers = 5;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(120, actualPrice);
    }

    [Fact]
    public void PriceWithCheckedBagsReturnsBasePricePlusCheckedBagPrice()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 3;
        int numCarryOn = 0;
        int numPassengers = 1;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(175, actualPrice);
    }

    [Fact]
    public void PriceWithCarryOnBagsReturnsBasePricePlusCarryOnBagPrice()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 0;
        int numCarryOn = 4;
        int numPassengers = 1;

        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(102, actualPrice);
    }

    [Fact]
    public void PriceWithTotalPriceGreaterThan500ReturnsPriceWithDiscount()
    {
        // Arrange
        BaggageCalculator calculator = new();
        int numChecked = 2;
        int numCarryOn = 2;
        int numPassengers = 1;
        
        // Act
        decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers);

        // Assert
        Assert.Equal(170, actualPrice);
    }
}