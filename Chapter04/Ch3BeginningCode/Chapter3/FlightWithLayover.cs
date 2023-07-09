namespace Packt.CloudySkiesAir.Chapter3; 

public class FlightWithLayover : FlightBase {
    public string LayoverLocation { get; set; }
    public TimeSpan LayoverDuration { get; set; }
    public TimeSpan DepartureDuration { get; set; }

    public FlightWithLayover(string depLoc, string layLoc, DateTime arrTime, TimeSpan layDur, 
        DateTime depTime, string arrLoc, TimeSpan depDur)
        : base(depLoc, depTime, arrLoc, arrTime) {
        LayoverLocation = layLoc;
        LayoverDuration = layDur;
        DepartureDuration = depDur;
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
        return $"Flight from {DepartureLocation} to {ArrivalLocation} with a " +
            $"layover at {LayoverLocation} for {DoTheHourFormat(LayoverDuration.TotalHours)}. " +
            $"Overall time: {DoTheHourFormat(TotalDuration.TotalHours)}";
    }

    private string DoTheHourFormat(double numHours) {
        return (numHours == 1)
            ? $"{numHours} hour"
            : $"{numHours} hours";
    }
}