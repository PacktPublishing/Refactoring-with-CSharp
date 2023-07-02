namespace Packt.CloudySkiesAir.Chapter4;

public class FreightFlightInfo : IFlightInfo {
  public string Id { get; set; }
  public Airport DepartureLocation { get; set; }
  public Airport ArrivalLocation { get; set; }
  public DateTime DepartureTime { get; set; }
  public DateTime ArrivalTime { get; set; }
  public TimeSpan Duration => DepartureTime - ArrivalTime;
  public string CharterCompany { get; set; }
  public string Cargo { get; set; }

  public override string ToString() {
    return $"{Id} {DepartureLocation.Code}-{ArrivalLocation.Code} carrying {Cargo} for {CharterCompany}";
  }
}
