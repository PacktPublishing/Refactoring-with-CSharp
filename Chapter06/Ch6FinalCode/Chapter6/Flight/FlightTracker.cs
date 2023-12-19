using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling;
using Packt.CloudySkiesAir.Chapter6.Flight.Scheduling.Flights;
using Packt.CloudySkiesAir.Chapter6.Helpers;

namespace Packt.CloudySkiesAir.Chapter6.Flight;

public class FlightTracker {
  readonly FlightScheduler _scheduler;

  public FlightTracker(FlightScheduler scheduler) {
    _scheduler = scheduler;
  }

  public void DisplayFlights() {
    foreach (IFlightInfo f in _scheduler.GetAllFlights()) {
      Console.WriteLine($"{f.Id,-9} {f.Arrival.Location.Name,-5} {f.Departure.Time.Format(),-21} {f.Status}");
    }
  }

  public IFlightInfo? MarkFlightDelayed(string id, DateTime newDepartureTime) {
    return UpdateFlightIfFound(id, flight => {
      flight.Departure.Time = newDepartureTime;
      flight.Status = FlightStatus.Delayed;
      Console.WriteLine($"{id} delayed until {newDepartureTime.Format()}");
    });
  }

  public IFlightInfo? MarkFlightDeparted(string id, DateTime departureTime) {
    return UpdateFlightIfFound(id, flight => {
      flight.Departure.Time = departureTime;
      flight.Status = FlightStatus.Departed;
      Console.WriteLine($"{id} departed at {departureTime.Format()}.");
    });
  }

  public IFlightInfo? MarkFlightArrived(string id, DateTime arrivalTime) {
    return UpdateFlightIfFound(id, flight => {
      flight.Arrival.Time = arrivalTime;
      flight.Status = FlightStatus.OnTime;
      Console.WriteLine($"{id} arrived at {arrivalTime.Format()}.");
    });
  }

  IFlightInfo? UpdateFlightIfFound(string id, Action<IFlightInfo> updateAction) {
    IFlightInfo? flight = FindFlightById(id);
    if (flight != null) {
      updateAction(flight);
    } else {
      Console.WriteLine($"{id} could not be found");
    }
    return flight;
  }

  IFlightInfo? FindFlightById(string id) =>
      _scheduler.GetAllFlights().FirstOrDefault(f => f.Id == id);
}
