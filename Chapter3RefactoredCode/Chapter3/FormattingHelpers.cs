namespace Packt.CloudySkiesAir.Chapter3 {
    public static class FormattingHelpers {

        public static string FormatHours(this double numHours)
            => (numHours == 1) ? numHours + " hour" : numHours + " hours";

        public static string FormatHours(this TimeSpan duration)
            => FormatHours(duration.TotalHours);
    }
}