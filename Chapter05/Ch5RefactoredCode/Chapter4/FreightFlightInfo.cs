namespace Packt.CloudySkiesAir.Chapter4;

public class FreightFlightInfo : FlightInfoBase {
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public override string BuildFlightIdentifier() =>
    base.BuildFlightIdentifier() +
    $" carrying {Cargo} for {CharterCompany}";
}
