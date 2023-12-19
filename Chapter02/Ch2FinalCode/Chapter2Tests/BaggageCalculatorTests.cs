using Packt.CloudySkiesAir.Chapter2;

namespace Chapter2Tests;

public class BaggageCalculatorTests {
  [Fact]
  public void PriceWithNoBagsIsCorrect() {
    // Arrange
    BaggageCalculator calculator = new();
    const int numChecked = 0, numCarryOn = 0, numPassengers = 1;
    DateTime travelDate = new(2023, 3, 1);

    // Act
    decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month is >= 11 or <= 2);

    // Assert
    Assert.Equal(0, actualPrice);
  }

  [Fact]
  public void PriceWithTwoPassengersAndThreeCheckedIsCorrect() {
    // Arrange
    BaggageCalculator calculator = new();
    const int numChecked = 3, numCarryOn = 2, numPassengers = 2;
    DateTime travelDate = new(2023, 3, 1);

    // Act
    decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month is >= 11 or <= 2);

    // Assert
    Assert.Equal(190M, actualPrice);
  }

  [Fact]
  public void PriceWithCarryOnBagIsCorrect() {
    // Arrange
    BaggageCalculator calculator = new();
    const int numChecked = 0;
    const int numCarryOn = 1;
    const int numPassengers = 1;
    DateTime travelDate = new(2023, 3, 1);

    // Act
    decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month is >= 11 or <= 2);

    // Assert
    Assert.Equal(30M, actualPrice);
  }

  [Fact]
  public void PriceWithTwoCheckedIsCorrect() {
    // Arrange
    BaggageCalculator calculator = new();
    const int numChecked = 2, numCarryOn = 1, numPassengers = 1;
    DateTime travelDate = new(2023, 3, 1);

    // Act
    decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month is >= 11 or <= 2);

    // Assert
    Assert.Equal(120M, actualPrice);
  }

  [Fact]
  public void HolidayPriceIsCorrect() {
    // Arrange
    BaggageCalculator calculator = new();
    const int numChecked = 3, numCarryOn = 2, numPassengers = 2;
    DateTime travelDate = new(2023, 12, 19);

    // Act
    decimal actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month is >= 11 or <= 2);

    // Assert
    Assert.Equal(209M, actualPrice);
  }
}