namespace Packt.CloudySkiesAir.Chapter3;

public class LinqExamples {

  public static void UseCorrectMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    Passenger? author = people.FirstOrDefault(p => p.FullName == "Matt Eland");

    if (author != null) {
      Console.WriteLine($"{author.FullName} is in group {author.BoardingGroup}");
    }
  }

  public static void CombineLinqMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    var anyBoarded = people.Any(p => p.HasBoarded);
    var numBoarded = people.Count(p => p.HasBoarded);
    Passenger firstBoarded = people.First(p => p.HasBoarded);
  }

  public static void TransformingWithSelect() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

var names = 
      people.Where(p => !p.HasBoarded)
            .Select(p => $"{p.FullName}-{p.BoardingGroup}")
            .ToList();      
  }

  public static void EnumeratingWithTakeAndSkip() {
    PassengerGenerator generator = new();
    var people = generator.GeneratePassengers(50)
                                      .OrderBy(p => p.BoardingGroup)
                                      .ToList();

    foreach (Passenger p in people.SkipWhile(p => p.BoardingGroup < 3).Take(3)) {
      Console.WriteLine($"Upgrading {p.FullName}");
    }

  }

  public static void RangeIndexers() {
    PassengerGenerator generator = new();
    var people = generator.GeneratePassengers(50).ToList();

    var firstThree = people[0..3];
    var lastThree = people[^3..^0];
    var last = people[^1];
  }
}
