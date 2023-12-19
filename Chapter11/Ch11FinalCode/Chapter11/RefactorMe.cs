namespace Packt.CloudySkiesAir.Chapter11;

public class RefactorMe {

/// <summary>
/// Displays a sequence of 10 random numbers.
/// </summary>
public static void DisplayRandomNumbers() {
    List<int> numbers = new(10);
    Random rand = new();

    foreach (int _ in Enumerable.Range(0, 10)) {
      int number = rand.Next(1, 101);
      numbers.Add(number);
    }

    string output = string.Join(", ", numbers);
    Console.WriteLine(output);
  }
}
