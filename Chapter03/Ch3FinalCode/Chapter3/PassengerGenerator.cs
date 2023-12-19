using Bogus;

namespace Packt.CloudySkiesAir.Chapter3; 

public class PassengerGenerator {
  static readonly Random _random = new();
  readonly Faker _faker = new();

  public Passenger GeneratePassenger() {
    string firstName = _faker.Name.FirstName();
    string lastName = _faker.Name.LastName();
    int boardingGroup = _random.Next(1, 8);
    bool needsAssistance = _random.NextDouble() < 0.15;
    bool isMilitary = _random.NextDouble() < 0.05;

    return new Passenger() { 
      FirstName = firstName, 
      LastName = lastName, 
      BoardingGroup = boardingGroup, 
      IsMilitary = isMilitary, 
      NeedsHelp = needsAssistance 
    };
  }

  public List<Passenger> GeneratePassengers(int count) {
    List<Passenger> passengers = [];
    for (int i = 0; i < count; i++) {
      passengers.Add(GeneratePassenger());
    }

    return passengers;
  }
}