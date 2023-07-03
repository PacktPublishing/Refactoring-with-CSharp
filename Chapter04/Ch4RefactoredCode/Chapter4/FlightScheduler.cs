using Packt.CloudySkiesAir.Chapter4.Filters;

namespace Packt.CloudySkiesAir.Chapter4;

public class FlightScheduler {
  private readonly List<IFlightInfo> _flights = new();

  public void ScheduleFlight(string id, Airport depart, Airport arrive, DateTime departTime, DateTime arriveTime, int passengers) {
    PassengerFlightInfo flight = new() {
      Id = id,
      Arrival = new AirportEvent(arrive, arriveTime),
      Departure = new AirportEvent(depart, departTime),
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

  FlightSearch searchParams = new() {
    Arrive = arrive,
    MinArrive = minArriveTime,
    MaxArrive = maxArriveTime,
    Depart = depart,
    MinDepart = minDepartTime,
    MaxDepart = maxDepartTime,
    MinLength = minLength,
    MaxLength = maxLength
  };

  return Search(searchParams);
}

  public IEnumerable<IFlightInfo> Search(FlightSearch s) {

    IEnumerable<IFlightInfo> results = _flights;

    if (s.Depart != null) {
      results =
        results.Where(f => f.Departure.Location == s.Depart);
    }

    if (s.Arrive != null) {
      results =
        results.Where(f => f.Arrival.Location == s.Arrive);
    }

    if (s.MinDepart != null) {
      results =
        results.Where(f => f.Departure.Time >= s.MinDepart);
    }

    if (s.MaxDepart != null) {
      results = 
        results.Where(f => f.Departure.Time <= s.MaxDepart);
    }

    if (s.MinArrive != null) {
      results = 
        results.Where(f => f.Arrival.Time >= s.MinArrive);
    }

    if (s.MaxArrive != null) {
      results = 
        results.Where(f => f.Arrival.Time <= s.MaxArrive);
    }

    if (s.MinLength != null) {
      results = 
        results.Where(f => f.Duration >= s.MinLength);
    }

    if (s.MaxLength != null) {
      results = 
        results.Where(f => f.Duration <= s.MaxLength);
    }

    return results;
  }

  public IEnumerable<IFlightInfo> Search(
    IEnumerable<FlightFilterBase> rules) => 
    _flights.Where(f => rules.All(r => r.ShouldInclude(f)));
}
