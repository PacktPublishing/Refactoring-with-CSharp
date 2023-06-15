namespace Packt.CloudySkiesAir.Chapter3.Tests;

public class FlightWithLayoverTests
{
    private readonly DateTime _departureTime = new DateTime(2022, 1, 1, 7, 0, 0);
    private readonly DateTime _arrivalTime = new DateTime(2022, 1, 1, 10, 0, 0);
    private readonly string _departureLocation = "Seoul";
    private readonly string _arrivalLocation = "New York";
    private readonly TimeSpan _departureDuration = TimeSpan.FromHours(1);
    private readonly TimeSpan _layoverDuration = TimeSpan.FromHours(2);
    private readonly string _layoverLocation = "Dubai";


    [Fact]
    public void FlightWithLayoverToString_ReturnsExpectedString()
    {
        // Arrange
        var flightWithLayover = new FlightWithLayover(_departureLocation, _departureTime, _departureDuration, _layoverLocation, _layoverDuration, _arrivalLocation, _arrivalTime);
        var expectedResult = $"Flight from {_departureLocation} to {_arrivalLocation} with a layover at {_layoverLocation} for {_layoverDuration.TotalHours} hours. Overall time: {flightWithLayover.TotalDuration.TotalHours} hours";

        // Act
        var result = flightWithLayover.ToString();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void FlightWithLayoverGetFlightDetails_ReturnsExpectedString()
    {
        // Arrange
        var flightWithLayover = new FlightWithLayover(_departureLocation, _departureTime, _departureDuration, _layoverLocation, _layoverDuration, _arrivalLocation, _arrivalTime);
        var expectedResult = $"Flight from {_departureLocation} to {_arrivalLocation} with a layover at {_layoverLocation} for {_layoverDuration.TotalHours} hours. Overall time: {flightWithLayover.TotalDuration.TotalHours} hours";

        // Act
        var result = flightWithLayover.GetFlightDetails();

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void FlightWithLayoverTotalDuration_ReturnsExpectedTimeSpan()
    {
        // Arrange
        var flightWithLayover = new FlightWithLayover(_departureLocation, _departureTime, _departureDuration, _layoverLocation, _layoverDuration, _arrivalLocation, _arrivalTime);
        var expectedTotalDuration = _departureDuration + _layoverDuration + (_arrivalTime - _departureTime);

        // Act
        var result = flightWithLayover.TotalDuration;

        // Assert
        Assert.Equal(expectedTotalDuration, result);
    }
}
