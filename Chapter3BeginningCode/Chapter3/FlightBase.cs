namespace Packt.CloudySkiesAir.Chapter3;

public class FlightBase {
    public string DepartureLocation { get; set; }
    public string ArrivalLocation { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }

    public FlightBase(string departureLocation, DateTime departureTime,
                      string arrivalLocation, DateTime arrivalTime) {
        DepartureLocation = departureLocation;
        ArrivalLocation = arrivalLocation;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
    }

    public virtual TimeSpan TotalDuration {
        get {
            return ArrivalTime - DepartureTime;
        }
    }

    public virtual string GetFlightDetails() {
        return $"From {DepartureLocation} to {ArrivalLocation} on {DepartureTime}. Arriving at {ArrivalTime}";
    }
}