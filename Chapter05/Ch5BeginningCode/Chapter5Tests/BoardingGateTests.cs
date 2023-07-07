using Packt.CloudySkiesAir.Chapter5;

public class BoardingGateTests
{
    private readonly BoardingGate _gate;

    public BoardingGateTests()
    {
        _gate = new BoardingGate();
    }

    [Fact]
    public void CanPassengerBoard_Returns_PriorityLane_When_IsMilitary_And_Time_IsPassenger_BoardStartTime()
    {
        // Arrange
        bool isMilitary = true;
        int currentBoardingGroup = 1;
        int boardingPassGroup = 2;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now;
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Board Now via the Priority Lane", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_PriorityLane_When_NeedsHelp_And_Time_IsPassenger_BoardStartTime()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 1;
        int boardingPassGroup = 2;
        bool needsHelp = true;
        DateTime boardingStart = DateTime.Now;
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Board Now via the Priority Lane", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_PriorityLane_When_CurrentBoardingGroup_Is_LessOrEqual_MaxPriorityLane()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 2;
        int boardingPassGroup = 1;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now;
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Board Now via the Priority Lane", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_NormalLane_When_CurrentBoardingGroup_Is_GreaterThan_MaxPriorityLane()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 4;
        int boardingPassGroup = 2;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now;
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Board Now via the Normal Lane", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_PleaseWaitForYourGroup_When_CurrentBoardingGroup_Is_LessThan_BoardingPassGroup()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 1;
        int boardingPassGroup = 2;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now;
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Please Wait for your Group", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_PleaseWaitForBoardingToStart_When_Time_IsLessThan_BoardingStart()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 2;
        int boardingPassGroup = 1;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now.AddMinutes(10);
        bool hasFlightDeparted = false;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("Please Wait for Boarding to Start", result);
    }

    [Fact]
    public void CanPassengerBoard_Returns_YouMissedYourFlight_When_hasFlightDeparted_IsTrue()
    {
        // Arrange
        bool isMilitary = false;
        int currentBoardingGroup = 2;
        int boardingPassGroup = 1;
        bool needsHelp = false;
        DateTime boardingStart = DateTime.Now.AddMinutes(-5);
        bool hasFlightDeparted = true;

        // Act
        string result = _gate.CanPassengerBoard(isMilitary, currentBoardingGroup, boardingPassGroup, needsHelp, boardingStart, hasFlightDeparted);

        // Assert
        Assert.Equal("You missed your flight", result);
    }
}
