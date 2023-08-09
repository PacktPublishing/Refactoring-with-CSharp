using GitHub;
using Moq;
using Packt.CloudySkiesAir.Chapter9.Flight.Boarding;
using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;
using Shouldly;
using Snapper;
using Snapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter9Tests; 

public class FlightBookingManagerTests {

    [Fact]
    public void BookingFlightShouldSendEmails() {
        // Arrange
        Mock<IEmailClient> mockClient = new();
        mockClient.Setup(c => c.SendMessage(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IEmailClient emailClient = mockClient.Object;

        FlightBookingManager manager = new(emailClient);

        Passenger passenger =  new() {
            FirstName = "Dot",
            LastName = "Nette",
            Email = "noreply@packt.com"
        };
        FlightInfo flight = GenerateEmptyFlight("Madrid", "Mexico City");

        // Act
        bool result = manager.BookFlight(passenger, flight, "22C");

        // Assert
        result.ShouldBeTrue();
        mockClient.Verify(c => c.SendMessage(passenger.Email, It.IsAny<string>()), Times.Once);
        mockClient.VerifyNoOtherCalls();
    }

    [Fact]
    //[UpdateSnapshots]
    public void FlightManifestShouldMatchExpectations() {
        // Arrange
        FlightInfo flight = GenerateEmptyFlight("Buenos Ares", "Laos");
        Passenger p1 = new() { FirstName = "Dot", LastName = "Netta" };
        Passenger p2 = new() { FirstName = "See", LastName = "Sharp" };
        flight.AssignSeat(p1, "1A");
        flight.AssignSeat(p2, "1B");
        LegacyManifestGenerator generator = new();  

        // Act
        FlightManifest manifest = generator.Build(flight);

        // Assert
        manifest.ShouldMatchSnapshot();
    }

    [Fact]
    public void FlightManifestExperimentWithScientist() {
        FlightInfo flight = GenerateEmptyFlight("Buenos Ares", "Laos");
        Passenger p1 = new() { FirstName = "Dot", LastName = "Netta" };
        Passenger p2 = new() { FirstName = "See", LastName = "Sharp" };

        Scientist.Science<FlightManifest>("build flight manifest", exp => {
            exp.Use(() => {
                LegacyManifestGenerator generator = new();
                return generator.Build(flight);
            });
            exp.Try(() => {
                RewrittenManifestGenerator generator = new();
                return generator.Build(flight);
            });
            exp.Compare((a, b) => a.Arrival.Code == b.Arrival.Code &&
                                  a.Departure.Code == b.Departure.Code &&
                                  a.PassengerCount == b.PassengerCount);
            exp.ThrowOnMismatches = true;
        });
    }


    private static FlightInfo GenerateEmptyFlight(string from, string to) {
        return new() {
            Departure = new Airport() { Name = from },
            Arrival = new Airport() { Name = to },
        };
    }
}
