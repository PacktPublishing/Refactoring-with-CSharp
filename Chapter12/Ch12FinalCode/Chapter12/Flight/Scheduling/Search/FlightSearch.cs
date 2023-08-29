namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Search;

public class FlightSearch {
  public Airport? Depart { get; set; }
  public Airport? Arrive { get; set; }
  public DateTime? MinArrive { get; set; }
  public DateTime? MaxArrive { get; set; }
  public DateTime? MinDepart { get; set; }
  public DateTime? MaxDepart { get; set; }
  public TimeSpan? MinLength { get; set; }
  public TimeSpan? MaxLength { get; set; }
}