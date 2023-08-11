using Bogus;
using Moq;
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
    public void BoardingMessageShouldBeAccurate() {
        // Arrange
        Passenger passenger = new() {
            BoardingGroup = 7,
            FirstName = "Dot",
            LastName = "Nette",
            MailingCity = "Columbus",
            MailingState = "Ohio",
            MailingCountry = "United States",
            MailingPostalCode = "43081",
            Email = "noreply@packt.com",
            RewardsId = "CSA88121",
            RewardMiles = 360,
            IsMilitary = false,
            NeedsHelp = false,
        };
        BoardingProcessor boarding = new(BoardingStatus.Boarding, group:3);

        // Act
        string message = boarding.BuildMessage(passenger);

        // Assert
        message.ShouldBe("Please Wait");
    }

    [Fact]
    public void BoardingMessageShouldBeAccurateWithBogus() {
        Faker<Passenger> faker = BuildPersonFaker();

        Passenger passenger = faker.Generate();
        passenger.BoardingGroup = 7;
        passenger.NeedsHelp = false;
        passenger.IsMilitary = false;

        BoardingProcessor boarding = new(BoardingStatus.Boarding, group: 3);

        // Act
        string message = boarding.BuildMessage(passenger);

        // Assert
        message.ShouldBe("Please Wait");
    }

    private static Faker<Passenger> BuildPersonFaker() {
        // Arrange
        Faker<Passenger> faker = new();
        faker.RuleFor(p => p.FirstName, f => f.Person.FirstName)
             .RuleFor(p => p.LastName, f => f.Person.LastName)
             .RuleFor(p => p.Email, f => f.Person.Email)
             .RuleFor(p => p.MailingCity, f => f.Address.City())
             .RuleFor(p => p.MailingCountry, f => f.Address.Country())
             .RuleFor(p => p.MailingState, f => f.Address.State())
             .RuleFor(p => p.MailingPostalCode, f => f.Address.ZipCode())
             .RuleFor(p => p.RewardsId, f => f.Rant.Review())
             .RuleFor(p => p.RewardMiles, f => f.Random.Number(int.MaxValue));
        return faker;
    }
}
