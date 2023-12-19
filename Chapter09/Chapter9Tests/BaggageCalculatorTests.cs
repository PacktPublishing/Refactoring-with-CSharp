using Packt.CloudySkiesAir.Chapter9.Flight.Baggage;
using FluentAssertions;

namespace Chapter9Tests;

public class BaggageCalculatorTests {
  [Fact]
  public void CarryOnBaggageIsPricedCorrectly() {
    // Arrange
    BaggageCalculator calculator = new();
    const int carryOnBags = 2, checkedBags = 0, passengers = 1;
    const bool isHoliday = false;

    // Act
    decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

    // Assert
    result.Should().Be(60m);
    result.Should().BePositive().And.BeInRange(50, 70);
  }

  [Fact]
  public void FirstCheckedBagShouldCostExpectedAmount() {
    // Arrange
    BaggageCalculator calculator = new();
    const int carryOnBags = 0;
    const int checkedBags = 1;
    const int passengers = 1;
    const bool isHoliday = false;

    // Act
    decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

    // Assert
    result.Should().NotBe(0);
    result.Should().BeGreaterThan(20);
    result.Should().Be(40);
  }

  [Theory]
  [InlineData(0, 0, 1, false, 0)]
  [InlineData(2, 3, 2, false, 190)]
  [InlineData(2, 1, 1, false, 100)]
  [InlineData(2, 3, 2, true, 209)]
  public void BaggageCalculatorCalculatesCorrectPrice(int carryOnBags, int checkedBags, int passengers, bool isHoliday, decimal expected) {
    // Arrange
    BaggageCalculator calculator = new();

    // Act
    decimal result = calculator.CalculatePrice(checkedBags, carryOnBags, passengers, isHoliday);

    // Assert
    result.Should().Be(expected);
  }
}