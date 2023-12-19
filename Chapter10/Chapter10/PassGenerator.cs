using Bogus;

namespace Packt.CloudySkiesAir.Chapter10;

public static class PassGenerator {
  public static List<BoardingPass> Generate() {
    Faker faker = new();
    List<BoardingPass> passes = [];

    for (int i = 0; i < 15; i++) {
      BoardingPass pass = new(faker.Name.FullName()) {
        Flight = GenerateFlight(faker),
        Seat = faker.Random.Int(1, 60) + faker.Random.String2(2, "ABCDEF"),
        Group = faker.Random.Number(1, 8)
      };

      passes.Add(pass);
    }

    return passes;
  }

  static FlightInfo GenerateFlight(Faker faker)
    => new() {
      ArrivalTime = faker.Date.Future(),
      DepartureTime = faker.Date.Soon(),
      Destination = faker.Address.City(),
      Origin = faker.Address.City(),
      Miles = faker.Random.Number(200, 2500),
      Status = faker.PickRandom<FlightStatus>(),
      Id = "CSA" + faker.Random.Number(1000, 9999)
    };
}
