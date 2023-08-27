namespace Packt.CloudySkiesAir.Chapter10.DevServer;
public class FlightInfo {
    public string Id { get; set; }
    public FlightStatus Status { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int Miles { get; set; }
}