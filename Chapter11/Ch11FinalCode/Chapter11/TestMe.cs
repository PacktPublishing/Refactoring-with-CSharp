namespace Packt.CloudySkiesAir.Chapter11;

public static class TestMe {
  public static int CalculateLargestNumberWithoutASeven(
    INumberProvider provider) {
    var numbers = provider.GenerateNumbers();

    return numbers == null
      ? 0
      : numbers.Where(x => !x.ToString().Contains('7'))
               .Max();
  }
}
