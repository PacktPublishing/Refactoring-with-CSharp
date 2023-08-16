using Packt.CloudySkiesAir.Chapter9.Flight.Boarding;

namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling {
  public record FlightManifest {
    public Passenger[] Passengers { get; internal set; }
    public string[] BookedSeats { get; internal set; }
    public int PassengerCount { get; internal set; }
    public Airport Arrival { get; internal set; }
    public Airport Departure { get; internal set; }
  }
}