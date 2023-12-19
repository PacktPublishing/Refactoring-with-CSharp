using Packt.CloudySkiesAir.Chapter9.Flight.Boarding;

namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

public class FlightInfo {
  readonly Dictionary<string, Passenger> _bookedSeats = [];
  public required Airport Departure { get; set; }
  public required Airport Arrival { get; set; }

  public IReadOnlyDictionary<string, Passenger> CurrentBookings => _bookedSeats.AsReadOnly();

  public void AssignSeat(Passenger passenger, string seat) {
    _bookedSeats[seat.ToLower()] = passenger;
  }

  public bool IsSeatAvailable(string seat) {
    return !_bookedSeats.ContainsKey(seat.ToLower());
  }
}