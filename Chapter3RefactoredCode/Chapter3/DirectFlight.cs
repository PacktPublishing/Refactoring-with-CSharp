namespace Packt.CloudySkiesAir.Chapter3; 

public class DirectFlight : FlightBase {
    public DirectFlight(string departureLocation, DateTime departureTime, string arrivalLocation, DateTime arrivalTime) 
        : base(departureLocation, departureTime, arrivalLocation, arrivalTime) {
    }

    public override string GetFlightDetails() 
        => $"Direct flight {base.GetFlightDetails()}";
}