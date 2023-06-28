namespace Packt.CloudySkiesAir.Chapter3 {
    public static class FormattingHelpers {

        public static string FormatHours(this double numHours)
            => (Math.Abs(numHours - 1) < double.Epsilon) ? numHours + " hour" : numHours + " hours";

        public static string FormatHours(this TimeSpan duration)
            => FormatHours(duration.TotalHours);
    }
}