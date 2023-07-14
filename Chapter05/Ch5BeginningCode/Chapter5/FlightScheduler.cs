using Packt.CloudySkiesAir.Chapter5.AirTravel;

namespace Packt.CloudySkiesAir.Chapter5;

public class FlightScheduler {
  private readonly List<IFlightInfo> _flights = new();

  public void ScheduleFlight(string id, Airport depart, Airport arrive, DateTime departTime, DateTime arriveTime, int passengers) {
    PassengerFlightInfo flight = new() {
      Id = id,
      ArrivalLocation = arrive,
      ArrivalTime = arriveTime,
      DepartureLocation = depart,
      DepartureTime = departTime,      
    };
    flight.Load(passengers);

    _flights.Add(flight);

    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void ScheduleFlight(IFlightInfo flight) {
    _flights.Add(flight);

    Console.WriteLine($"Scheduled Flight {flight}");
  }

  public void RemoveFlight(IFlightInfo flight) {
    _flights.Remove(flight);
  }

  public IEnumerable<IFlightInfo> GetAllFlights() {
    return _flights.AsReadOnly();
  }

  public IEnumerable<IFlightInfo> Search(
    Airport? depart, Airport? arrive,
    DateTime? minDepartTime, DateTime? maxDepartTime,
    DateTime? minArriveTime, DateTime? maxArriveTime,
    TimeSpan? minLength, TimeSpan? maxLength) {

    IEnumerable<IFlightInfo> results = _flights;

    if (depart != null) {
      results = results.Where(f =>
        f.DepartureLocation.Code == depart.Code &&
        f.DepartureLocation.Country == depart.Country
      );
    }

    if (arrive != null) {
      results = results.Where(f =>
        f.ArrivalLocation.Code == arrive.Code &&
        f.ArrivalLocation.Country == arrive.Country
      );
    }

    if (minDepartTime != null) {
      results = results.Where(f => f.DepartureTime >= minDepartTime);
    }

    if (maxDepartTime != null) {
      results = results.Where(f => f.DepartureTime <= maxDepartTime);
    }

    if (minArriveTime != null) {
      results = results.Where(f => f.ArrivalTime >= minArriveTime);
    }

    if (maxArriveTime != null) {
      results = results.Where(f => f.ArrivalTime <= maxArriveTime);
    }

    if (minLength != null) {
      results = results.Where(f => f.Duration >= minLength);
    }

    if (maxLength != null) {
      results = results.Where(f => f.Duration <= maxLength);
    }

    return results;
  }
}
