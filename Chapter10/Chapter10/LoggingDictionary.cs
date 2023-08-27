namespace Packt.CloudySkiesAir.Chapter10;

public class FlightDictionary {
  private readonly Dictionary<string, FlightInfo> _items =
    new();
  public bool Contains(string identifier)
    => _items.ContainsKey(identifier);
  public void AddItem(string id, FlightInfo item) {
    Console.WriteLine($"Adding {id}");
    _items[id] = item;
  }
  public FlightInfo? GetItem(string id) {
    if (Contains(id)) {
      Console.WriteLine($"Found {id}");
      return _items[id];
    }
    Console.WriteLine($"Could not find {id}");
    return null;
  }
}

public class BoardingPassDictionary {
  private readonly Dictionary<string, BoardingPass> _items =
    new();
  public bool Contains(string identifier)
    => _items.ContainsKey(identifier);
  public void AddItem(string id, BoardingPass item) {
    Console.WriteLine($"Adding {id}");
    _items[id] = item;
  }
  public BoardingPass? GetItem(string id) {
    if (Contains(id)) {
      Console.WriteLine($"Found {id}");
      return _items[id];
    }
    Console.WriteLine($"Could not find {id}");
    return null;
  }
}

public class LoggingDictionary<TKey, TValue> {
  private readonly Dictionary<TKey, TValue> _items =
    new();
  public bool Contains(TKey identifier)
    => _items.ContainsKey(identifier);
  public void AddItem(TKey id, TValue item) {
    Console.WriteLine($"Adding {id}");
    _items[id] = item;
  }
  public TValue? GetItem(TKey id) {
    if (Contains(id)) {
      Console.WriteLine($"Found {id}");
      return _items[id];
    }
    Console.WriteLine($"Could not find {id}");
    return default(TValue);
  }
}

