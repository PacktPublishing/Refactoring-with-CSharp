using Packt.CloudySkiesAir.Chapter9.Flight;
using Shouldly;

namespace Chapter9Tests; 

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
        message.ShouldBe("Flight CSA1234 is On Time");
    }
}