namespace Packt.CloudySkiesAir.Chapter3; 

public class FlightWithLayover : FlightBase {
    public string LayoverLocation { get; set; }
    public TimeSpan LayoverDuration { get; set; }
    public TimeSpan DepartureDuration { get; set; }

    public FlightWithLayover(string departureLocation, 
        DateTime departureTime, TimeSpan departureDuration, 
        string layoverLocation, TimeSpan layoverDuration, 
        string arrivalLocation, DateTime arrivalTime)
        : base(departureLocation, departureTime, arrivalLocation, arrivalTime) {
        LayoverLocation = layoverLocation;
        LayoverDuration = layoverDuration;
        DepartureDuration = departureDuration;
    }

    public override TimeSpan TotalDuration 
        => base.TotalDuration + LayoverDuration + DepartureDuration;

    public override string GetFlightDetails() 
        => $"Flight from {DepartureLocation} to {ArrivalLocation} with a " +
           $"layover at {LayoverLocation} for {LayoverDuration.TotalHours.FormatHours()}. " +
           $"Overall time: {TotalDuration.TotalHours.FormatHours()}";
}