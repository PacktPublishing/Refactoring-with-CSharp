namespace Packt.CloudySkiesAir.Chapter3; 

public class FlightWithLayover : FlightBase {
    public string LayoverLocation { get; set; }
    public TimeSpan LayoverDuration { get; set; }
    public TimeSpan DepartureDuration { get; set; }

    public FlightWithLayover(string departureLocation, DateTime departureTime, TimeSpan departureDuration,
                             string layoverLocation, TimeSpan layoverDuration,
                             string arrivalLocation, DateTime arrivalTime) 
        : base(departureLocation, departureTime, arrivalLocation, arrivalTime) {
        LayoverLocation = layoverLocation;
        LayoverDuration = layoverDuration;
        DepartureDuration = departureDuration;
    }

    public override TimeSpan TotalDuration {
        get {
            return base.TotalDuration + LayoverDuration + DepartureDuration;
        }
    }

    public override string ToString() {
        return GetFlightDetails();
    }

    public override string GetFlightDetails() {
        return $"Flight from {DepartureLocation} to {ArrivalLocation} with a layover at {LayoverLocation} " +
            $"for {GetHoursString(LayoverDuration.TotalHours)}. " +
            $"Overall time: {GetHoursString(TotalDuration.TotalHours)}";
    }

    private string GetHoursString(double numHours) {
        if (numHours == 1) {
            return numHours + " hour";
        } else {
            return numHours + " hours";
        }
    }
}