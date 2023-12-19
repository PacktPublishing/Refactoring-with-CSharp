namespace Packt.CloudySkiesAir.Chapter8;

public class FlightBookingManagerViolatesDependencyInversion {
  readonly SpecificMailClient _email;
  public FlightBookingManagerViolatesDependencyInversion(string connectionString) {
    _email = new SpecificMailClient(connectionString);
  }

  public bool BookFlight(Passenger passenger,
    PassengerFlightInfo flight, string seat) {
    if (!flight.IsSeatAvailable(seat)) {
      return false;
    }

    flight.AssignSeat(passenger, seat);

    string message = "Your seat is confirmed";
    _email.SendMessage(passenger.Email, message);

    return true;
  }
}
