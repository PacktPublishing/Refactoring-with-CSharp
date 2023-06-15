namespace Packt.CloudySkiesAir.Chapter3; 

public class FlightWithLayover : FlightBase {
    public string LayoverLocation { get; set; }
    public TimeSpan LayoverDuration { get; set; }
    public TimeSpan DepartureDuration { get; set; }

    public FlightWithLayover(string depLoc, DateTime depTime, TimeSpan depDur,
                             string layLoc, TimeSpan layDur,
                             string arrLoc, DateTime arrTime) 
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
        return $"Flight from {DepartureLocation} to {ArrivalLocation} with a layover at {LayoverLocation} " +
            $"for {MakeTheHoursNotLookAwful(LayoverDuration.TotalHours)}. " +
            $"Overall time: {MakeTheHoursNotLookAwful(TotalDuration.TotalHours)}";
    }

    private string MakeTheHoursNotLookAwful(double numHours) {
        if (numHours == 1) {
            return numHours + " hour";
        } else {
            return numHours + " hours";
        }
    }
}