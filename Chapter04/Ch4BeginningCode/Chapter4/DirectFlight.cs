namespace Packt.CloudySkiesAir.Chapter4;

public class DirectFlight : FlightBase {
    public DirectFlight(string departureLocation, DateTime departureTime, string arrivalLocation, DateTime arrivalTime)
        : base(departureLocation, departureTime, arrivalLocation, arrivalTime) {
    }

    public override string ToString() {
        return GetFlightDetails();
    }

    public override string GetFlightDetails() {
        return $"Direct flight {base.GetFlightDetails()}";
    }
}