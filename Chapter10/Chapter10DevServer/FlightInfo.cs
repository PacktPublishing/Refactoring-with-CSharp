namespace Packt.CloudySkiesAir.Chapter10.DevServer;
public class FlightInfo {
  public string Id { get; set; } = default!;
  public FlightStatus Status { get; set; }
  public string Origin { get; set; } = default!;
  public string Destination { get; set; } = default!;
  public DateTime DepartureTime { get; set; }
  public DateTime ArrivalTime { get; set; }
  public int Miles { get; set; }
}