namespace Packt.CloudySkiesAir.Chapter11;
public class RefactorMe {
  public void DisplayRandomNumbers() {
    List<int> numbers = new List<int>();
    for (int i = 1; i <= 10; i++) {
      Random rand = new Random();
      int n = rand.Next(1, 101);
      numbers.Add(n);
    }
    String output = string.Join(", ", numbers.ToArray());
    Console.WriteLine(output);
  }
}
