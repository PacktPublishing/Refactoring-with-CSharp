namespace Packt.CloudySkiesAir.Chapter11;

public static class TestMe {
  public static int CalculateLargestNumberWithoutASeven(
    INumberProvider provider) {
    IEnumerable<int> numbers = provider.GenerateNumbers();
    return numbers.Where(x => !x.ToString().Contains("7"))
                  .Max();
  }
}

