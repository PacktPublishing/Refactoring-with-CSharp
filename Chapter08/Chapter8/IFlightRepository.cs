using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter8;

// This interface violates the interface segregation principle.
// A better model would be to separate it into IFlightProvider and IFlightRepository

// Note: in a real application FlightRepository would probably be expanded to support these methods
// However, in order to keep the code readable, FlightRepository does not implement all these capabilities

public interface IFlightRepository { 
  FlightInfo AddFlight(FlightInfo flight);
  FlightInfo UpdateFlight(FlightInfo flight);
  void CancelFlight(FlightInfo flight);
  FlightInfo? FindFlight(string id);
  IEnumerable<FlightInfo> GetActiveFlights();
  IEnumerable<FlightInfo> GetPendingFlights();
  IEnumerable<FlightInfo> GetCompletedFlights();
}
