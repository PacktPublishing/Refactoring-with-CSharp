namespace Packt.CloudySkiesAir.Chapter3;

public static class LinqExamples {
  public static void UseCorrectMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    Passenger? author = people.Find(p => p.FullName == "Matt Eland");

    if (author != null) {
      Console.WriteLine($"{author.FullName} is in group {author.BoardingGroup}");
    }
  }

  public static void CombineLinqMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    bool anyBoarded = people.Any(p => p.HasBoarded);
    int numBoarded = people.Count(p => p.HasBoarded);
    Passenger firstBoarded = people.First(p => p.HasBoarded);
  }

  public static void TransformingWithSelect() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    List<string> names =
      people.Where(p => !p.HasBoarded)
            .Select(p => $"{p.FullName}-{p.BoardingGroup}")
            .ToList();
  }

  public static void EnumeratingWithTakeAndSkip() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50)
                                      .OrderBy(p => p.BoardingGroup)
                                      .ToList();

    foreach (Passenger p in people.SkipWhile(p => p.BoardingGroup < 3).Take(3)) {
      Console.WriteLine($"Upgrading {p.FullName}");
    }
  }

  public static void RangeIndexers() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50).ToList();

    _ = people[0..3];

    _ = people[^3..^0];

    _ = people[^1];
  }
}
