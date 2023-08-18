using Packt.CloudySkiesAir.Chapter9.Flight.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter9Tests.Doubles;
public class TestEmailClient : IEmailClient
{
    public bool SendMessage(string email, string message) => true;
}
