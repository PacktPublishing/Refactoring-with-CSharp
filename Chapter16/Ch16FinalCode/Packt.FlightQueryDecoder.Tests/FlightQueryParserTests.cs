using Shouldly;

namespace Packt.FlightQueryDecoder.Tests {
    public class FlightQueryParserTests {

        [Fact]
        public void FlightQueryParserShouldParseFlightQueries() {
            // Arrange
            FlightQueryParser parser = new();
            string query = "AD08FEBDENLHR";

            // Act
            FlightQuery result = parser.ParseQuery(query);

            // Assert
            result.ShouldNotBeNull();
            result.Date.ShouldBe(new DateTime(DateTime.Today.Year, 2, 8));
            result.Origin.ShouldBe("DEN");
            result.Destination.ShouldBe("LHR");
        }

        [Fact]
        public void FlightQueryParserShouldParseFlightQueryResults() {
            // Arrange
            FlightQueryParser parser = new();
            string query = "DEN LHR 05:50P 09:40A E0/789 8:50";

            // Act
            FlightQueryResult result = parser.ParseResult(query);

            // Assert
            result.ShouldNotBeNull();
            result.Origin.ShouldBe("DEN");
            result.Destination.ShouldBe("LHR");
            result.AircraftTypeDesignator.ShouldBe("E0/789");
            result.DepartureTime.ToShortTimeString().ShouldBe("5:50 PM");
            result.ArrivalTime.ToShortTimeString().ShouldBe("9:40 AM");
        }
    }
}