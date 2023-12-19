using System.Security;

namespace Packt.CloudySkiesAir.Chapter8.AntiPatterns;

public class CatchingExceptionAntiPatterns {
  public static void DontCatchException1() {
    try {
      AMethodThatMayThrowExceptions();
    }
    catch (Exception ex) {
      // Error handling logic 
    }
  }

  public static void DontCatchException2() {
    try {
      AMethodThatMayThrowExceptions();
    }
    catch { // same as catch (Exception ex) above
      // Error handling logic 
    }
  }

  public static void DoCatchSpecificExceptions() {
    try {
      AMethodThatMayThrowExceptions();
    }
    catch (SecurityException ex) {
      // Error handling logic 
    }
    catch (IOException ex) {
      // Error handling logic 
    }
  }

  /// <summary>
  /// This method exists to randomly throw exceptions. 
  /// This is not a serious method and you should never do anything like this.
  /// </summary>
  /// <exception cref="FileNotFoundException">Thrown if a file could not be found</exception>
  /// <exception cref="SecurityException">Thrown if you do not have access to the specific resource</exception>
  public static void AMethodThatMayThrowExceptions() {
    switch (Random.Shared.Next(3)) {
      case 0:
        break;
      case 1:
        // Note: FileNotFoundException inherits from IOException and will be caught by catch blocks for that
        throw new FileNotFoundException("Could not find a file at [some path]");
      case 2:
        throw new SecurityException("Ah ah ah; you didn't say the magic word.");
    }
  }

}
