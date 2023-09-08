using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.FlightQueryDecoder {
    public class FlightQuery {
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination {
            get;
            set;
        }
    }
}
