using Bogus;
using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;
using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;
using Shouldly;

namespace Chapter9Tests;

public class FlightSchedulerTests {

    private readonly Faker<Airport> _airportFaker;
    private readonly Faker<PassengerFlightInfo> _flightFaker;

    public FlightSchedulerTests() {
        _airportFaker = new Faker<Airport>()
            .RuleFor(a => a.Country, f => f.Address.Country())
            .RuleFor(a => a.Name, f => f.Address.City())
            .RuleFor(a => a.Code, f => f.Random.String2(3));

        _flightFaker = new Faker<PassengerFlightInfo>()
            .RuleFor(p => p.Id, f => f.Random.AlphaNumeric(length: 6))
            .RuleForType(typeof(int), f => f.Random.Number(min: 16, max: 480))
            .RuleForType(typeof(AirportEvent), f => new AirportEvent() {
                Location = _airportFaker.Generate(),
                Time = f.Date.Future()
            })
            .RuleForType(typeof(FlightStatus), f => f.PickRandom<FlightStatus>());
            
        //_airport1 = new() {
        //    Code = _bogus.Random.String2(3).ToUpper(),
        //    Country = _bogus.Address.Country(),
        //    Name = _bogus.Company.CompanyName(),
        //};
    }

    [Fact]
    public void ScheduleFlightShouldAddFlight() {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = _flightFaker.Generate();

        // Act
        scheduler.ScheduleFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        result.ShouldNotBeNull();
        result.Count().ShouldBe(1);
        result.ShouldContain(flight);
    }


    [Fact]
    public void ScheduleFlightShouldNotBeSlow() {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = _flightFaker.Generate();

        // Act / Assert
        TimeSpan maxTime = TimeSpan.FromMilliseconds(100);
        Should.CompleteIn(() => scheduler.ScheduleFlight(flight), maxTime);
    }

    [Fact]
    public void RemoveShouldRemoveFlight() {
        // Arrange
        FlightScheduler scheduler = new();
        PassengerFlightInfo flight = _flightFaker.Generate();
        scheduler.ScheduleFlight(flight);

        // Act
        scheduler.RemoveFlight(flight);

        // Assert
        IEnumerable<IFlightInfo> result = scheduler.GetAllFlights();
        result.ShouldNotBeNull();
        result.ShouldNotContain(flight);
    }

}
