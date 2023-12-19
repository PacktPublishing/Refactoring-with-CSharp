namespace Packt.FlightQueryDecoder {
    public class FlightQuery {
        public DateTime Date { get; set; }
        public string Origin { get; set; } = default!;
        public string Destination { get; set; } = default!;
        }
}
