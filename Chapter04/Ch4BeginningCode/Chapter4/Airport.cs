using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter4; 

public class Airport {

  public string Code { get; set; }
  public string Name { get; set; }

  public List<Runway> Runways { get; set; }
}

public class Runway {
  public string Name { get; set; }
  public decimal LengthInMeters { get; set; }
  public bool HasApproachLights { get; set; }
  public string SurfaceType { get; set; }
}