using System;
using System.Collections.Generic;
using Packt.CloudySkiesAir.Chapter4.AirTravel;
using Xunit;

namespace Packt.CloudySkiesAir.Chapter4.Tests
{
    public class FlightSchedulerTests
    {
        private readonly FlightScheduler _flightScheduler;

        private readonly Airport _airport1;
        private readonly Airport _airport2;

        public FlightSchedulerTests()
        {
            _flightScheduler = new FlightScheduler();

            _airport1 = new Airport() {
                Code = "DNA",
                Country = "United States",
                Name = "Dotnet Airport"
            };
            _airport2 = new Airport() {
                Code = "CSI",
                Country = "United Kingdom",
                Name = "C# International Airport"
            };

        }

        [Fact]
        public void ScheduleFlight_Should_Add_Flight_To_FlightList()
        {
            // Arrange
            Airport departure = _airport1;
            Airport arrival = _airport2;

            // Act
            _flightScheduler.ScheduleFlight("CS2001", departure, arrival, DateTime.Now, DateTime.Now.AddHours(7));

            // Assert
            IEnumerable<IFlightInfo> result = _flightScheduler.GetAllFlights();
            Assert.Contains(result, f => f.Id == "CS2001");
        }

        [Fact]
        public void SearchShouldReturnMatchingFlights()
        {
            // Arrange
            DateTime departTime = DateTime.Today.AddHours(6.5);
            _flightScheduler.ScheduleFlight("CS2005", _airport2, _airport1, departTime, departTime.AddHours(14.5));

            // Act
            IEnumerable<IFlightInfo> result = _flightScheduler.Search(null, null, DateTime.Today, null, null, null, null, null);

            // Assert
            Assert.NotEmpty(result);
            Assert.Single(result);
            Assert.Equal("CS2005", result.First().Id);
        }


        [Fact]
        public void SearchShouldNotReturnHiddenFlights() {
            // Arrange
            DateTime departTime = DateTime.Today.AddHours(6.5);
            _flightScheduler.ScheduleFlight("CS2005", _airport2, _airport1, departTime, departTime.AddHours(14.5));

            // Act
            IEnumerable<IFlightInfo> result = _flightScheduler.Search(_airport1, null, null, null, null, null, null, null);

            // Assert
            Assert.Empty(result);
        }

    }
}
