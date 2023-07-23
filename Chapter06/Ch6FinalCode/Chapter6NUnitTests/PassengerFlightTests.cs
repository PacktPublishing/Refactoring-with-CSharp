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
        PassengerFlightInfo flight = new();

        // Act
        flight.Load(passengers);

        // Assert
        int actual = flight.Passengers;
        Assert.AreEqual(passengers, actual);
        Assert.That(actual, Is.EqualTo(passengers));
    }
}