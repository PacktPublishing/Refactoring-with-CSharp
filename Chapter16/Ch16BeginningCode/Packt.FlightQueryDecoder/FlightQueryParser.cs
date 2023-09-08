namespace Packt.FlightQueryDecoder; 

public class FlightQueryParser 
{

    public FlightQuery ParseQuery(string query) {
        if (query.StartsWith("AD") && query.Length == 13) 
        {
            var flightQuery = new FlightQuery {
                Date = DateTime.Parse(query.Substring(2, 5)),
                Origin = query.Substring(7, 3),
                Destination = query.Substring(10, 3)
            };
            return flightQuery;
        } 
        else {
            throw new ArgumentException("Invalid query format.");
        }
    }

    public FlightQueryResult ParseResult(string result) {
        var fqr = new FlightQueryResult();
        var segments = result.Split(' ',
          StringSplitOptions.RemoveEmptyEntries
          | StringSplitOptions.TrimEntries);
        fqr.Origin = segments[0];
        fqr.Destination = segments[1];
        string today = DateTime.Today.ToShortDateString();
        fqr.DepartureTime = DateTime.Parse(
          today + " " + segments[2] + 'M');
        string seg3 = segments[3];
        fqr.ArrivalTime = DateTime.Parse($"{today} {seg3}M");
        fqr.AircraftTypeDesignator = segments[4];
        fqr.FlightDuration = TimeSpan.Parse(segments[5]);
        return fqr;
    }

}
