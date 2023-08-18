namespace Packt.CloudySkiesAir.Chapter9.Helpers;

public static class DateHelpers {
  public static string Format(this DateTime time) {
    return time.ToString("ddd MMM dd HH:mm tt");
  }
}