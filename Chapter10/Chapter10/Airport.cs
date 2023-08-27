using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter10; 

public record class Airport {
  public required string Name { get; init; }
  public required string Code { get; init; }
}
