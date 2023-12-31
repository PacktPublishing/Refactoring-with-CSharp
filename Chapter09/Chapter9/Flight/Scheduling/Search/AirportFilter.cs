﻿using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;

namespace Packt.CloudySkiesAir.Chapter9.Flight.Scheduling.Search;

public class AirportFilter : FlightFilterBase {
  public bool IsDeparture { get; set; }
  public Airport Airport { get; set; }
  public override bool ShouldInclude(IFlightInfo flight) {
    if (IsDeparture) {
      return flight.Departure.Location == Airport;
    }
    return flight.Arrival.Location == Airport;
  }
}
