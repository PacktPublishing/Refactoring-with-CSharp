using Bogus;

namespace Packt.CloudySkiesAir.Chapter10.DevServer;

public class RandomFlightDataProvider : IFlightProvider {

    private readonly Dictionary<string, FlightInfo> _flights = new();

    public RandomFlightDataProvider() {
        var faker = new Faker();
        for (int i = 0; i < 20; i++) {
            FlightInfo flight = new() {
                Id = "CSA" + faker.Random.Number(1000, 9999),
                Origin = faker.Address.City(),
                Destination = faker.Address.City(),
                DepartureTime = DateTime.Now.AddMinutes(faker.Random.Number(-500, 500)),
                Miles = faker.Random.Number(100, 2000),
            };

            const int planeMph = 525;

            flight.ArrivalTime = flight.DepartureTime + TimeSpan.FromHours(flight.Miles / planeMph);

            UpdateStatus(flight);

            _flights.Add(flight.Id.ToLower(), flight);
        }
    }

    private static void UpdateStatus(FlightInfo flight) {
        if (flight.DepartureTime > DateTime.Now) {
            flight.Status = FlightStatus.Pending;
        } else if (flight.ArrivalTime > DateTime.Now) {
            flight.Status = FlightStatus.Active;
        } else {
            flight.Status = FlightStatus.Completed;
        }
    }

    public FlightInfo? FindFlight(string id) {
        string key = id.ToLower();
        if (_flights.ContainsKey(key)) {
            FlightInfo flight = _flights[id.ToLower()];
            UpdateStatus(flight);

            return flight;
        }
        return null;
    }

    public IEnumerable<FlightInfo> UpdateStatuses() {
        foreach (FlightInfo flight in _flights.Values) {
            UpdateStatus(flight);

            yield return flight;
        }
    }

    public IEnumerable<FlightInfo> GetActiveFlights() => 
        UpdateStatuses().Where(f => f.Status == FlightStatus.Active);

    public IEnumerable<FlightInfo> GetAllFlights() =>
        UpdateStatuses();

    public IEnumerable<FlightInfo> GetFlightsUpToMileage(int miles) =>
        UpdateStatuses().Where(f => f.Miles <= miles);

    public IEnumerable<FlightInfo> GetCompletedFlights() =>
        UpdateStatuses().Where(f => f.Status == FlightStatus.Completed);

    public IEnumerable<FlightInfo> GetPendingFlights() =>
        UpdateStatuses().Where(f => f.Status == FlightStatus.Pending);
}