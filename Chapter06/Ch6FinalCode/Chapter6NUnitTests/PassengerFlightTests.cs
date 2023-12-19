using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Chapter6NUnitTests; 

public class PassengerFlightTests {
    [SetUp]
    public void Setup() {
    }

    [Test]
    [TestCase(6)]
    public void AddingAPassengerShouldResultInPassengers(int passengers) {
        // Arrange
        PassengerFlightInfo flight = new PassengerFlightInfo();

        // Act
        flight.Load(passengers);

        // Assert
        int actual = flight.Passengers;
        Assert.That(actual, Is.EqualTo(passengers));
        Assert.That(actual, Is.EqualTo(passengers));
    }
}