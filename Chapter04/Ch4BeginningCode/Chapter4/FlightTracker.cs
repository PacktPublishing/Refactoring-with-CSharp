namespace Packt.CloudySkiesAir.Chapter4;

public class FlightTracker {
    private readonly List<Flight> _flights = new();

    public Flight ScheduleNewFlight(string id, string dest, DateTime depart, string gate) {
        Flight flight = new() {
            Id = id,
            Destination = dest,
            DepartureTime = depart,
            Gate = gate,
            Status = FlightStatus.Inbound
        };
        _flights.Add(flight);
        return flight;
    }

    public void DisplayFlights() {
        foreach (Flight f in _flights) {
            Console.WriteLine($"{f.Id,-9} {f.Destination, -5} {Format(f.DepartureTime), -21} {f.Gate, -5} {f.Status}");
        }
    }

    public Flight? DelayFlight(string fId, DateTime newTime) {
        Flight? flight = FindFlightById(fId);

        if (flight != null) {
            flight.DepartureTime = newTime;
            flight.Status = FlightStatus.Delayed;
            Console.WriteLine($"{fId} delayed until {Format(newTime)}");
        } else {
            Console.WriteLine($"{fId} could not be found");
        }
        return flight;
    }

    public Flight? MarkFlightArrived(DateTime time, string id) {
        Flight? flight = FindFlightById(id);
        if (flight != null) {
            flight.ArrivalTime = time;
            flight.Status = FlightStatus.OnTime;
            Console.WriteLine($"{id} arrived at {Format(time)}.");
        } else {
            Console.WriteLine($"{id} could not be found");
        }
        return flight;
    }

    public Flight? MarkFlightDeparted(string id, DateTime t) {
        Flight? flight = FindFlightById(id);
        if (flight != null) {
            flight.DepartureTime = t;
            flight.Status = FlightStatus.Departed;
            Console.WriteLine($"{id} departed at {Format(t)}.");
        } else {
            Console.WriteLine($"{id} could not be found");
        }
        return flight;
    }

    public Flight? FindFlightById(string id) {
        return _flights.FirstOrDefault(f => f.Id == id);
    }

    private string Format(DateTime time) {
        return time.ToString("ddd MMM dd HH:mm tt");
    }
}