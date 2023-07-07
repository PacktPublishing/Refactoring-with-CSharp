using Packt.CloudySkiesAir.Chapter5;

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
            var bp = new BoardingProcessor {
                Status = BoardingStatus.InProgress,
                CurrentBoardingGroup = currentGroup,
            };

            var result = bp.CanPassengerBoard(isMilitary, passengerGroup, needsHelp);

            Assert.Equal(expectedResult, result);
    }
}
