using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;
using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

namespace Chapter6XUnitTests;

public class FlightSchedulerTests {

    readonly Airport _airport1;
    readonly Airport _airport2;

    public FlightSchedulerTests() {
        _airport1 = new() {
            Code = "DNA",
            Country = "United States",
            Name = "Dotnet Airport"
        };
        _airport2 = new() {
            Code = "CSI",
            Country = "United Kingdom",
            Name = "C# International Airport"
        };
    }

    [Fact]
    public void ScheduleFlightShouldAddFlight() {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");

        // Act
        scheduler.ScheduleFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.Contains(flight, result);
    }

    PassengerFlightInfo CreateFlight(string id)
      => new() {
          Id = id,
          Status = FlightStatus.OnTime,
          Departure = new AirportEvent() {
              Location = _airport1,
              Time = DateTime.Now
          },
          Arrival = new AirportEvent() {
              Location = _airport2,
              Time = DateTime.Now.AddHours(2)
          }
      };

    [Fact]
    public void RemoveShouldRemoveFlight() {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = CreateFlight("CS2024");
        scheduler.ScheduleFlight(flight);

        // Act
        scheduler.RemoveFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        Assert.NotNull(result);
        Assert.DoesNotContain(flight, result);
    }
}
