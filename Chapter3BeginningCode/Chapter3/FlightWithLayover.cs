namespace Packt.CloudySkiesAir.Chapter3; 

public class FlightWithLayover : FlightBase {
    public string LayoverLocation { get; set; }
    public TimeSpan LayoverDuration { get; set; }

    public FlightWithLayover(string departureLocation, DateTime departureTime,
                             string layoverLocation, TimeSpan layoverDuration,
                             string arrivalLocation, DateTime arrivalTime) 
        : base(departureLocation, departureTime, arrivalLocation, arrivalTime) {
        LayoverLocation = layoverLocation;
        LayoverDuration = layoverDuration;
    }

    public override TimeSpan TotalDuration {
        get {
            return base.TotalDuration + LayoverDuration;
        }
    }

    public override string ToString() {
        return GetFlightDetails();
    }

    public override string GetFlightDetails() {
        return $"Flight with a {GetHoursString(LayoverDuration.TotalHours)} layover at {LayoverLocation}. {base.GetFlightDetails()}";
    }

    private string GetHoursString(double numHours) {
        if (numHours <= 1) {
            return numHours + " hour";
        } else {
            return numHours + " hours";
        }
    }
}