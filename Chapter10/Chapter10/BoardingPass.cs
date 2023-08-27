namespace Packt.CloudySkiesAir.Chapter10;

public record class BoardingPass(string passenger) {
  public required FlightInfo Flight { get; init; }
  public required int Group { get; init; }
  public required string Seat { get; init; }

  public override string ToString() =>
    $"{passenger} in group {Group} " +
    $"for seat {Seat} of {Flight.Id}";
}
