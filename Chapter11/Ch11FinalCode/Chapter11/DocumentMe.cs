namespace Packt.CloudySkiesAir.Chapter11;

public class DocumentMe {

  /// <summary>
  /// Adds up even numbers in an array.
  /// </summary>
  /// <param name="numbers">The array of numbers to add.</param>
  /// <param name="total">The starting total to add to. Defaults to 0.</param>
  /// <returns>The total of all even numbers in the array.</returns>
  /// <exception cref="ArgumentException">Thrown when the array is null or empty.</exception>
  public static int AddEvenNumbers(int[]? numbers, int total = 0) {
    if (numbers == null || numbers.Length == 0) {
      const string message = "There must be at least 1 element";
      throw new ArgumentException(message, nameof(numbers));
    }

    return total + numbers.Where(n => n % 2 == 0).Sum();
  }
}
