namespace Packt.CloudySkiesAir.Chapter11;

public static class Program {
  public static void Main() {
    RefactorMe refactorMe = new();
    RefactorMe.DisplayRandomNumbers();

    DocumentMe documentMe = new();
    DocumentMe.AddEvenNumbers([1, 2, 3], 42);
  }
}