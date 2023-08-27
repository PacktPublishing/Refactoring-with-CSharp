namespace Packt.CloudySkiesAir.Chapter10;

public class FlightInfo {
    public string Id { get; set; }
    public FlightStatus Status { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int Miles { get; set; }

  public override string ToString() => 
    $"{Id} from {Origin} to {Destination} at {DepartureTime.ToShortTimeString()} " +
    $"on {DepartureTime.ToShortDateString()}. Status: {Status}";
}