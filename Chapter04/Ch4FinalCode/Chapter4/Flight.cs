namespace Packt.CloudySkiesAir.Chapter4;

public class Flight(string id, string destination, DateTime departureTime) {
    public Flight(string id, string destination, DateTime departureTime, FlightStatus status) : this(id, destination, departureTime) {
        Status = status;
    }

    public string Id { get; set; } = id;
    public string Destination { get; set; } = destination;
    public DateTime DepartureTime { get; set; } = departureTime;
    public DateTime ArrivalTime { get; set; }
    public string Gate { get; set; } = default!;
    public FlightStatus Status { get; set; }

    public override string ToString() {
        return $"{Id} to {Destination} at {DepartureTime}";
    }
}
