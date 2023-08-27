using Packt.CloudySkiesAir.Chapter12.Flight.Scheduling.Search;

namespace Packt.CloudySkiesAir.Chapter12.Flight.Scheduling;

public class FlightScheduler {
  private readonly List<IFlightInfo> _flights = new();

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

  public IEnumerable<IFlightInfo> Search(FlightSearch s) {
    IEnumerable<IFlightInfo> results = _flights;

    if (s.Depart != null) {
      results = results.Where(f => f.Departure.Location == s.Depart);
    }

    if (s.Arrive != null) {
      results = results.Where(f => f.Arrival.Location == s.Arrive);
    }

    if (s.MinDepart != null) {
      results = results.Where(f => f.Departure.Time >= s.MinDepart);
    }

    if (s.MaxDepart != null) {
      results = results.Where(f => f.Departure.Time <= s.MaxDepart);
    }

    if (s.MinArrive != null) {
      results = results.Where(f => f.Arrival.Time >= s.MinArrive);
    }

    if (s.MaxArrive != null) {
      results = results.Where(f => f.Arrival.Time <= s.MaxArrive);
    }

    if (s.MinLength != null) {
      results = results.Where(f => f.Duration >= s.MinLength);
    }

    if (s.MaxLength != null) {
      results = results.Where(f => f.Duration <= s.MaxLength);
    }

    return results;
  }

  public List<IFlightInfo> Search(List<FlightFilterBase> rules) =>
      _flights.Where(f => rules.All(r => r.ShouldInclude(f)))
              .ToList();
}
