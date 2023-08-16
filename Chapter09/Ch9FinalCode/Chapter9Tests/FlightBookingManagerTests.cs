using Chapter9Tests.Doubles;
using GitHub;
using Moq;
using NSubstitute;
using NSubstitute.Core.Arguments;
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
    public void BookingFlightShouldSucceedForEmptyFlightTestDouble() {
        // Arrange
        TestEmailClient emailClient = new();
        FlightBookingManager manager = new(emailClient);
        Passenger passenger = GenerateTestPassenger();
        FlightInfo flight = GenerateEmptyFlight("Paris", "Toronto");

        // Act
        bool booked = manager.BookFlight(passenger, flight, "2B");

        // Assert
        booked.ShouldBeTrue();
    }

    [Fact]
    public void BookingFlightShouldSucceedForEmptyFlight() {
        // Arrange
        Mock<IEmailClient> clientMock = new();
        IEmailClient emailClient = clientMock.Object;
        FlightBookingManager manager = new(emailClient);
        Passenger passenger = GenerateTestPassenger();
        FlightInfo flight = GenerateEmptyFlight("Hamburg", "Cairo");

        // Act
        bool booked = manager.BookFlight(passenger, flight, "2B");

        // Assert
        booked.ShouldBeTrue();
    }


    [Fact]
    public void BookingFlightShouldSendEmails() {
        // Arrange
        Mock<IEmailClient> mockClient = new();
        mockClient.Setup(c => c.SendMessage(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        IEmailClient emailClient = mockClient.Object;

        FlightBookingManager manager = new(emailClient);
        Passenger passenger = GenerateTestPassenger();
        FlightInfo flight = GenerateEmptyFlight("Sydney", "Los Angelas");

        // Act
        bool result = manager.BookFlight(passenger, flight, "22C");

        // Assert
        result.ShouldBeTrue();
        mockClient.Verify(c => c.SendMessage(passenger.Email, It.IsAny<string>()), Times.Once);
        mockClient.VerifyNoOtherCalls();
    }


    [Fact]
    public void BookingFlightShouldSendEmailsNSubstitute() {
        // Arrange
        IEmailClient emailClient = Substitute.For<IEmailClient>();
        emailClient.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

        FlightBookingManager manager = new(emailClient);
        Passenger passenger = GenerateTestPassenger();
        FlightInfo flight = GenerateEmptyFlight("Sydney", "Los Angelas");

        // Act
        bool result = manager.BookFlight(passenger, flight, "22C");

        // Assert
        result.ShouldBeTrue();
        emailClient.Received().SendMessage(passenger.Email, Arg.Any<string>());
    }

    private static Passenger GenerateTestPassenger() {
        return new() {
            FirstName = "Dot",
            LastName = "Nette",
            Email = "noreply@packt.com"
        };
    }

[Fact]
[UpdateSnapshots]
public void FlightManifestShouldMatchExpectations() {
    // Arrange
    FlightInfo flight = GenerateEmptyFlight("Alta", "Laos");
    Passenger p1 = new("Dot", "Netta");
    Passenger p2 = new("See", "Sharp");
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
    Passenger p1 = new("Dot", "Netta");
    Passenger p2 = new("See", "Sharp");

    Scientist.Science<FlightManifest>("build flight manifest", exp => {
        exp.Use(() => {
            LegacyManifestGenerator generator = new();
            return generator.Build(flight);
        });
        exp.Try(() => {
            RewrittenManifestGenerator generator = new();
            return generator.Build(flight);
        });
        exp.Compare((a, b) => a.Arrival == b.Arrival &&
                              a.Departure == b.Departure &&
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
