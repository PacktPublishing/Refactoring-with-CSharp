﻿namespace Packt.CloudySkiesAir.Chapter8;

public class PassengerFlightInfo : FlightInfo {

  private readonly Dictionary<string, Passenger> _seats = new();

  public void AssignSeat(Passenger passenger, string seat) {
    _seats[seat] = passenger;
  }

  public bool IsSeatAvailable(string seat) 
    => _seats.ContainsKey(seat);
}