namespace Packt.CloudySkiesAir.Chapter4;

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

  // TODO: Wrap parameters in an object
  public IEnumerable<IFlightInfo> Search(Airport? departureLocation, Airport? arrivalLocation, DateTime? minDepartureTime, DateTime? maxDepartureTime, DateTime? minArrivalTime, DateTime? maxArrivalTime, TimeSpan? minDuration, TimeSpan? maxDuration) {
    IEnumerable<IFlightInfo> filteredList = _flights;

    if (departureLocation != null) {
      filteredList = filteredList.Where(f => f.DepartureLocation.Code == departureLocation.Code && f.DepartureLocation.Country == departureLocation.Country);
    }

    if (arrivalLocation != null) {
      filteredList = filteredList.Where(f => f.ArrivalLocation.Code == arrivalLocation.Code && f.ArrivalLocation.Country == arrivalLocation.Country);
    }

    if (minDepartureTime != null) {
      filteredList = filteredList.Where(f => f.DepartureTime >= minDepartureTime);
    }

    if (maxDepartureTime != null) {
      filteredList = filteredList.Where(f => f.DepartureTime <= maxDepartureTime);
    }

    if (minArrivalTime != null) {
      filteredList = filteredList.Where(f => f.ArrivalTime >= minArrivalTime);
    }

    if (maxArrivalTime != null) {
      filteredList = filteredList.Where(f => f.ArrivalTime <= maxArrivalTime);
    }

    if (minDuration != null) {
      filteredList = filteredList.Where(f => f.Duration >= minDuration);
    }

    if (maxDuration != null) {
      filteredList = filteredList.Where(f => f.Duration <= maxDuration);
    }

    return filteredList;
  }
}
