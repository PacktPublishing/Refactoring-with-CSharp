namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public class FreightFlightInfo : FlightInfoBase {
  public required string CharterCompany { get; init; }
  public required string Cargo { get; init; }

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" {Cargo} for {CharterCompany}";
}