using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CloudySkiesAir.Chapter3; 

public class LinqExamples {

  public void UseCorrectMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    Passenger author = people.FirstOrDefault(p => p.FullName == "Matt Eland");

    Console.WriteLine($"{author.FullName} is in group {author.BoardingGroup}");
  }

  public void CombineLinqMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    bool anyBoarded = people.Any(p => p.HasBoarded);
    int numBoarded = people.Count(p => p.HasBoarded);
    Passenger firstBoarded = people.First(p => p.HasBoarded);
  }

  public void TransformingWithSelect() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

List<string> names = 
      people.Where(p => !p.HasBoarded)
            .Select(p => $"{p.FullName}-{p.BoardingGroup}")
            .ToList();      
  }

  public void EnumeratingWithTakeAndSkip() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50)
                                      .OrderBy(p => p.BoardingGroup)
                                      .ToList();

    foreach (Passenger p in people.SkipWhile(p => p.BoardingGroup < 3).Take(3)) {
      Console.WriteLine($"Upgrading {p.FullName}");
    }

  }

  public void RangeIndexers() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50).ToList();

    List<Passenger> firstThree = people[0..3];
    List<Passenger> lastThree = people[^3..^0];
    Passenger last = people[^1];
  }
}
