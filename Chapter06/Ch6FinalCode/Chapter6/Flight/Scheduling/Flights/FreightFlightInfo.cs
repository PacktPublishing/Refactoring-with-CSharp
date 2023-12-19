namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;

public class FreightFlightInfo : FlightInfoBase {
  public required string CharterCompany { get; set; }
  public required string Cargo { get; set; }

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" {Cargo} for {CharterCompany}";
}