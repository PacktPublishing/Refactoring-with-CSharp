namespace Packt.CloudySkiesAir.Chapter4; 

public class AirportEvent {
  public AirportEvent(Airport location) : this(location, 
    DateTime.Today.AddDays(1).AddHours(7.5)) {
  }
  public AirportEvent(Airport location, DateTime time) {
    Location = location;
    Time = time;
  }
  public Airport Location { get; set; }
  public DateTime Time { get; set; }
}