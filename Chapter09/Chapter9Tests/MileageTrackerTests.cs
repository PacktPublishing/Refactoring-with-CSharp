using Packt.CloudySkiesAir.Chapter9;

namespace Chapter9Tests;

public class MileageTrackerTests {
  [Fact]
  public void NewAccountShouldHaveStartingBalance() {
    // Arrange
    const int expectedMiles = 100;

    // Act
    MileageTracker tracker = new();

    // Assert
    tracker.Balance.ShouldBe(expectedMiles);
  }

  [Fact]
  public void AddMileageShouldIncreaseBalance() {
    // Arrange
    MileageTracker tracker = new();

    // Act
    tracker.AddMiles(50);

    // Assert
    tracker.Balance.ShouldBe(150);
  }

  [Fact]
  public void RemoveMileageShouldDecreaseBalance() {
    // Arrange
    MileageTracker tracker = new();
    tracker.AddMiles(900);

    // Act
    tracker.RedeemMiles(250);

    // Assert
    tracker.Balance.ShouldBe(750);
  }

  [Fact]
  public void RemoveMileageShouldPreventNegativeBalance() {
    // Arrange
    MileageTracker tracker = new();
    int startingBalance = tracker.Balance;

    // Act
    tracker.RedeemMiles(2500);

    // Assert
    tracker.Balance.ShouldBe(startingBalance);
  }

  [Theory]
  [InlineData(900, 250, 750)]
  [InlineData(0, 2500, 100)]
  public void RemoveMileageShouldResultInCorrectBalance(int addAmount, int redeemAmount, int expectedBalance) {
    // Arrange
    MileageTracker tracker = new();
    tracker.AddMiles(addAmount);

    // Act
    tracker.RedeemMiles(redeemAmount);

    // Assert
    tracker.Balance.ShouldBe(expectedBalance);
  }
}