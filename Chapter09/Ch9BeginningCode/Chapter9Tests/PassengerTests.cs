using Packt.CloudySkiesAir.Chapter9.Flight.Boarding;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter9Tests; 

public class PassengerTests {

    [Fact]
    public void PassengerFullNameShouldBeAccurate() {
        // Arrange
        Passenger passenger = new() {
            FirstName = "Dot",
            LastName = "Nette",
        };

        // Act
        string name = passenger.FullName;

        // Assert
        name.ShouldBe("Dot Nette");
    }

    [Fact]
    public void BoardingMessageShouldBeAccurate() { // Bogus
        // Arrange
        Passenger passenger = new() {
            BoardingGroup = 7,
            FirstName = "Dot",
            LastName = "Nette",
            MailingCity = "Columbus",
            MailingStateOrProvince = "Ohio",
            MailingCountry = "United States",
            MailingPostalCode = "43081",
            Email = "noreply@packt.com",
            RewardsId = "CSA88121",
            RewardMiles = 360,
            IsMilitary = false,
            NeedsHelp = false,
        };
        BoardingProcessor boarding = new() {
            Status = BoardingStatus.Boarding,
            CurrentBoardingGroup = 3
        };

        // Act
        string message = boarding.BuildMessage(passenger);

        // Assert
        message.ShouldBe("Please Wait");
    }
}
