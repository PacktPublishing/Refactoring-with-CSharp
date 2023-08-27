using Packt.CloudySkiesAir.Chapter12.Flight;

namespace Chapter12UnitTests;

public class FlightTests {
    [Fact]
    public void GeneratedMessageShouldBeCorrect() {
        // Arrange
        Flight flight = new();
        string id = "CSA1234";
        string status = "On Time";
        // Act
        string message = flight.BuildMessage(id, status);

        // Assert
        Assert.Equal("Flight CSA1234 is On Time", message);
    }
}