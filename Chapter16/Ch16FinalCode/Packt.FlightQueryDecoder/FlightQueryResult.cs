namespace Packt.FlightQueryDecoder {
    public class FlightQueryResult {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string AircraftTypeDesignator { get; internal set; }
        public TimeSpan FlightDuration { get; internal set; }
        public DateTime ArrivalTime { get; internal set; }
        public DateTime DepartureTime { get; internal set; }
    }
}