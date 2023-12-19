namespace Packt.CloudySkiesAir.Chapter8.AntiPatterns;

public static class ThrowingExceptionAntiPatterns {
  public static void DontThrowException() {
    // This forces someone to catch Exception in order to handle it
    throw new Exception("Something bad happened!");
  }

  public static void DoThrowBuiltInExceptions() {
    throw new InvalidOperationException("Flight not found");
  }

  public static void DoThrowCustomExceptionsWhenAppropriate() {
    throw new FlightNotFoundException("CS1234");
  }

  public static void DontRethrowWithThrowEx() {
    try {
      // Risky code
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine(ex.Message);
      throw ex; // this obscures the stack trace of the exception and makes it appear as if it occurred on this line
    }
  }

  public static void DoRethrowWithThrow() {
    try {
      // Risky code
    }
    catch (FlightNotFoundException ex) {
      Console.WriteLine(ex.Message);
      throw; // this preserves the original stack trace
    }
  }
}
