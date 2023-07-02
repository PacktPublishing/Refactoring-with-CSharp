namespace Packt.CloudySkiesAir.Chapter4;

public class FreightFlightInfo : FlightInfoBase, IFlightInfo {
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public override string ToString() {
    return $"{Id} {DepartureLocation}-{ArrivalLocation} carrying {Cargo} for {CharterCompany}";
  }
}
