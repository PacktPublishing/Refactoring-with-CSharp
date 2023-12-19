namespace Packt.CloudySkiesAir.Chapter3.Tests;

public class BoardingProcessorTests {

    [Theory]
    [InlineData(false, 4, false, 4, "Board Now")]
    [InlineData(false, 3, false, 2, "Please Wait")]
    [InlineData(false, 2, true, 2, "Board Now via Priority Lane")]
    [InlineData(false, 3, true, 2, "Board Now via Priority Lane")]
    [InlineData(false, 1, false, 2, "Board Now via Priority Lane")]
    [InlineData(true, 7, false, 1, "Board Now via Priority Lane")]
    [InlineData(true, 1, true, 2, "Board Now via Priority Lane")]
    [InlineData(true, 3, false, 2, "Board Now via Priority Lane")]
    [InlineData(true, 3, true, 2, "Board Now via Priority Lane")]
    public void CanPassengerBoard_ShouldReturnExpectedResult(
        bool isMilitary,
        int passengerGroup,
        bool needsHelp,
        int currentGroup,
        string expectedResult) {

        // Arrange
        BoardingProcessor bp = new() {
            Status = BoardingStatus.Boarding,
            CurrentBoardingGroup = currentGroup,
        };

        Passenger passenger = new() {
            FirstName = "Test",
            LastName = "Passenger",
            IsMilitary = isMilitary,
            BoardingGroup = passengerGroup,
            NeedsHelp = needsHelp,
        };

        // Act
        string result = bp.CanPassengerBoard(passenger);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
