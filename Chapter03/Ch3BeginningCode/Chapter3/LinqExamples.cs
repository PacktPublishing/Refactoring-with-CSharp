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

    Console.WriteLine($"{author.FullName} is group {author.BoardingGroup}");
  }

  public void CombineLinqMethods() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    bool anyBoarded =
      people.Where(p => p.HasBoarded).Any();
    int numBoarded =
      people.Where(p => p.HasBoarded).Count();
    Passenger firstBoarded =
      people.Where(p => p.HasBoarded).First();
  }

  public void TransformingWithSelect() {
    PassengerGenerator generator = new();
    List<Passenger> people = generator.GeneratePassengers(50);

    List<string> names = new();
    foreach (Passenger p in people) {
      if (!p.HasBoarded) {
        names.Add($"{p.FullName}-{p.BoardingGroup}");
      }
    }
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

    Passenger last = people[people.Count - 1];
  }
}
