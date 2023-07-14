namespace Packt.CloudySkiesAir.Chapter5;

public class FreightFlightInfo : FlightInfoBase {
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" {Cargo} for {CharterCompany}";
}
