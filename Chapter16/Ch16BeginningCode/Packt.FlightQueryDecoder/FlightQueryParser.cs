using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.FlightQueryDecoder {
    public class FlightQueryParser {

        // DEN LHR 430P 830A+1 E0/781 9:00
        // DEN LHR 550P 940A+1 E0/789 8:50

        public FlightQuery ParseQuery(string query) {
            if (query.StartsWith("AD") && query.Length == 13) {
                var flightQuery = new FlightQuery {
                    Date = DateTime.ParseExact(query.Substring(2, 5), "ddMMM", CultureInfo.InvariantCulture),
                    Origin = query.Substring(7, 3),
                    Destination = query.Substring(10, 3)
                };
                return flightQuery;
            } else {
                throw new ArgumentException("Invalid flight query format.", "query");
            }
        }

        public FlightQueryResult ParseResult(string result) {
            var flightQueryResult = new FlightQueryResult();

            var segments = result.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            flightQueryResult.Origin = segments[0];
            flightQueryResult.Destination = segments[1];

            string today = DateTime.Today.ToShortDateString();
            flightQueryResult.DepartureTime = DateTime.Parse(DateTime.Today.ToShortDateString() + " " + segments[2] + 'M');
            flightQueryResult.ArrivalTime = DateTime.Parse(DateTime.Today.ToShortDateString() + " " + segments[3] + 'M');
            flightQueryResult.AircraftTypeDesignator = segments[4];
            flightQueryResult.FlightDuration = TimeSpan.Parse(segments[5]);

            return flightQueryResult;
        }
    }
}
