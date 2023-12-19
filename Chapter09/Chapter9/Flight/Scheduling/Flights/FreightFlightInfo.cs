namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Flights;

public record FreightFlightInfo : FlightInfoBase {
  public string CharterCompany { get; set; } = default!;
  public string Cargo { get; set; } = default!;

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" {Cargo} for {CharterCompany}";
}