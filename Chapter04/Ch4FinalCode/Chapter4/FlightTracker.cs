namespace Packt.CloudySkiesAir.Chapter4;

public class FlightTracker {
    private readonly List<Flight> _flights = [];

    public Flight ScheduleNewFlight(string id, string dest, DateTime depart) {
        Flight flight = new(id, dest, depart) {
            Status = FlightStatus.Inbound
        };
        return ScheduleNewFlight(flight);
    }

    public Flight ScheduleNewFlight(Flight flight) {
        _flights.Add(flight);
        return flight;
    }

    public void DisplayFlights() {
        foreach (Flight f in _flights) {
            Console.WriteLine($"{f.Id,-9} {f.Destination,-5} {f.DepartureTime.Format(),-21} {f.Gate,-5} {f.Status}");
        }
    }

    public Flight? MarkFlightDelayed(string id, DateTime newDepartureTime) {
        void updateAction(Flight flight) {
            flight.DepartureTime = newDepartureTime;
            flight.Status = FlightStatus.Delayed;
            Console.WriteLine($"{id} delayed until {newDepartureTime.Format()}");
        }
        return UpdateFlight(id, updateAction);
    }

    public Flight? MarkFlightDeparted(string id, DateTime departureTime) {
        return UpdateFlight(id, flight => {
            flight.DepartureTime = departureTime;
            flight.Status = FlightStatus.Departed;
            Console.WriteLine($"{id} departed at {departureTime.Format()}.");
        });
    }

    public Flight? MarkFlightArrived(string id, DateTime arrivalTime, string gate = "TBD") {
        return UpdateFlight(id, flight => {
            flight.ArrivalTime = arrivalTime;
            flight.Gate = gate;
            flight.Status = FlightStatus.OnTime;
            Console.WriteLine($"{id} arrived at {arrivalTime.Format()}.");
        });
    }

    private Flight? UpdateFlight(string id, Action<Flight> updateAction) {
        Flight? flight = FindFlightById(id);
        if (flight != null) {
            updateAction(flight);
        } else {
            Console.WriteLine($"{id} could not be found");
        }
        return flight;
    }

    private Flight? FindFlightById(string id) => 
        _flights.FirstOrDefault(f => f.Id == id);
}