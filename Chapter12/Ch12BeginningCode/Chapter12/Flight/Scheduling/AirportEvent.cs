namespace Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;

public record class AirportEvent (Airport Location) {
  public DateTime Time { get; set; }
}
