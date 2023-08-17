using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter8.AntiPatterns;

public class ThrowingExceptionAntiPatterns {

  public void DontThrowException() {
    // This forces someone to catch Exception in order to handle it
    throw new Exception("Something bad happened!");
  }

  public void DoThrowBuiltInExceptions() {
    throw new InvalidOperationException("Flight not found");
  }

  public void DoThrowCustomExceptionsWhenAppropriate() {
    throw new FlightNotFoundException("CS1234");
  }

  public void DontRethrowWithThrowEx() {
    try {
      // Risky code
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine(ex.Message);
      throw ex; // this obscures the stack trace of the exception and makes it appear as if it occurred on this line
    }
  }

  public void DoRethrowWithThrow() {
    try {
      // Risky code
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine(ex.Message);
      throw; // this preserves the original stack trace
    }
  }
}
