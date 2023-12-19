using Packt.CloudySkiesAir.Chapter7;

namespace Chapter7Tests;

public class MileageTrackerTests {
  [Fact]
  public void NewAccountShouldHaveStartingBalance() {
    // Arrange
    const int expectedMiles = 100;

    // Act
    MileageTracker tracker = new();

    // Assert
    Assert.Equal(expectedMiles, tracker.Balance);
  }

  [Fact]
  public void AddMileageShouldIncreaseBalance() {
    // Arrange
    MileageTracker tracker = new();

    // Act
    tracker.AddMiles(50);

    // Assert
    Assert.Equal(150, tracker.Balance);
  }

  [Fact]
  public void RedeemMileageShouldDecreaseBalance() {
    // Arrange
    MileageTracker tracker = new();
    tracker.AddMiles(900);

    // Act
    tracker.RedeemMiles(250);

    // Assert
    Assert.Equal(750, tracker.Balance);
  }

  [Fact]
  public void RedeemMileageShouldPreventNegativeBalance() {
    // Arrange
    MileageTracker tracker = new();
    int startingBalance = tracker.Balance;

    // Act
    tracker.RedeemMiles(2500);

    // Assert
    Assert.Equal(startingBalance, tracker.Balance);
  }

  [Theory]
  [InlineData(900, 250, 750)]
  [InlineData(0, 2500, 100)]
  public void RedeemMileageShouldResultInCorrectBalance(int addAmount, int redeemAmount, int expectedBalance) {
    // Arrange
    MileageTracker tracker = new();
    tracker.AddMiles(addAmount);

    // Act
    tracker.RedeemMiles(redeemAmount);

    // Assert
    Assert.Equal(expectedBalance, tracker.Balance);
  }
}