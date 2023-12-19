namespace Packt.FlightQueryDecoder {
    public class FlightQueryResult {
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        public string AircraftTypeDesignator { get; internal set; } = default!;
        public TimeSpan FlightDuration { get; internal set; }
        public DateTime ArrivalTime { get; internal set; }
        public DateTime DepartureTime { get; internal set; }
    }
}