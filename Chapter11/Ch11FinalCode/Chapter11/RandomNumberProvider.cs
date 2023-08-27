namespace Packt.CloudySkiesAir.Chapter11;

public class RandomNumberProvider : INumberProvider {
  private readonly Random _random = new();
  private readonly int _numbersToGenerate;

  public RandomNumberProvider(int numbersToGenerate) {
    _numbersToGenerate = numbersToGenerate;
  }
  public IEnumerable<int> GenerateNumbers() {
    for (int i = 0; i < _numbersToGenerate; i++) {
      yield return _random.Next();
    }
  }
}
