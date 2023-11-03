# Refactoring with C#

<a href="https://www.packtpub.com/product/refactoring-with-c/9781835089989?utm_source=github&utm_medium=repository&utm_campaign=9781835089989"><img src="https://content.packt.com/B21324/cover_image_small.jpg" alt="Refactoring with C#" height="256px" align="right"></a>

This is the code repository for [Refactoring with C#](https://www.packtpub.com/product/refactoring-with-c/9781835089989?utm_source=github&utm_medium=repository&utm_campaign=9781835089989), published by Packt.

**Safely improve .NET applications and pay down technical debt with Visual Studio, .NET 8, and C# 12**

## What is this book about?
Software projects start as brand-new greenfield projects, but invariably become muddied in technical debt far sooner than you’d expect. In Refactoring with C#, you'll explore what technical debt is and how it arises before walking through the process of safely refactoring C# code using modern tooling in Visual Studio and more recent C# language features using C# 12 and .NET 8. This book will guide you through the process of refactoring safely through advanced unit testing with XUnit and libraries like Moq, Snapper, and Scientist .NET. You'll explore maintainable code through SOLID principles and defensive coding techniques made possible in newer versions of C#. You'll also find out how to run code analysis and write custom Roslyn analyzers to detect and resolve issues unique to your code.

This book covers the following exciting features:
* Understand technical debt, its causes and effects, and ways to prevent it
* Explore different ways of refactoring classes, methods, and lines of code
* Discover how to write effective unit tests supported by libraries such as Moq
* Understand SOLID principles and factors that lead to maintainable code
* Use AI to analyze, improve, and test code with the GitHub Copilot Chat
* Apply code analysis and custom Roslyn analyzers to ensure that code stays clean
* Communicate tech debt and code standards successfully in agile teams

If you feel this book is for you, get your [copy](https://www.amazon.com/dp/1835089984) today!

<a href="https://www.packtpub.com/?utm_source=github&utm_medium=banner&utm_campaign=GitHubBanner"><img src="https://raw.githubusercontent.com/PacktPublishing/GitHub/master/GitHub.png" 
alt="https://www.packtpub.com/" border="5" /></a>

## Instructions and Navigations
All of the code is organized into folders. For example, Chapter08.

The code will look like the following:
```
public interface IFlightRepository {
 FlightInfo AddFlight(FlightInfo flight);
 FlightInfo UpdateFlight(FlightInfo flight);
 void CancelFlight(FlightInfo flight);
 FlightInfo? FindFlight(string id); 
 IEnumerable<FlightInfo> GetActiveFlights();
 IEnumerable<FlightInfo> GetPendingFlights();
 IEnumerable<FlightInfo> GetCompletedFlights();
}
```

**Following is what you need for this book:**
This book is for any developer familiar with C# who wants to improve the code they work with on a day-to-day basis. While this book will be most beneficial to new developers with only a year or two of experience, even senior engineers and engineering managers can make the most of this book by exploring not just the process of refactoring, but advanced techniques with libraries like Moq, Snapper, Scientist .NET, and writing custom Roslyn analyzers.

With the following software and hardware list you can run all code files present in the book (Chapter 1-17).
### Software and Hardware List
| Chapter | Software required | OS required |
| -------- | ------------------------------------ | ----------------------------------- |
| 1-17 | Visual Studio 2022 v17.8 or higher | Windows |
| 1-17 | .NET 8 SDK |  |


### Related products
* Clean Code in C# [[Packt]](https://www.packtpub.com/product/clean-code-in-c/9781838982973?utm_source=github&utm_medium=repository&utm_campaign=9781838982973) [[Amazon]](https://www.amazon.com/dp/1838982973)

* Real-World Implementation of C# Design Patterns [[Packt]](https://www.packtpub.com/product/real-world-implementation-of-c-design-patterns/9781803242736?utm_source=github&utm_medium=repository&utm_campaign=9781803242736) [[Amazon]](https://www.amazon.com/dp/1803242736)


## Get to Know the Author
**Matt Eland**
is a software engineering leader and data scientist who has been using .NET since beta 2 in 2001. Matt has served as a senior engineer, software engineering manager, professional programming instructor, and has helped build enterprise-level software using C# at a variety of organisations before distinguishing himself as a Microsoft MVP.
Matt makes it his job to learn new things and share them with others through articles, videos, and talks at user groups and conferences covering a wide range of topics from software architecture to advanced .NET topics to artificial intelligence and data science. Matt is also a .NET Foundation member and the co-organizer of the Central Ohio .NET Developers Group.
