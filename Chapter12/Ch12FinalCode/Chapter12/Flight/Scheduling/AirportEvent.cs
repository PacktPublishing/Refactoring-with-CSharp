namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

public record class AirportEvent(Airport Location) {
  public DateTime Time { get; set; }
}
