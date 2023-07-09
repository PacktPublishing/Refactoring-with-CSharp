namespace Packt.CloudySkiesAir.Chapter4.Tests;

public class DirectFlightTests {
    private readonly DirectFlight _directFlight;
    private readonly DateTime _departureTime;
    private readonly DateTime _arrivalTime;

    public DirectFlightTests() {
        _departureTime = new DateTime(2022, 1, 1, 9, 0, 0);
        _arrivalTime = new DateTime(2022, 1, 1, 12, 0, 0);
        _directFlight = new DirectFlight("LAX", _departureTime, "JFK", _arrivalTime);
    }


    [Fact]
    public void ToString_ReturnsExpectedValue() {
        // Arrange
        string expected = _directFlight.GetFlightDetails();

        // Act
        string actual = _directFlight.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetFlightDetails_ReturnsExpectedValue() {
        // Arrange
        string expected = $"Direct flight from LAX to JFK on {_departureTime}. Arriving at {_arrivalTime}";

        // Act
        string actual = _directFlight.GetFlightDetails();

        // Assert
        Assert.Equal(expected, actual);
    }
}