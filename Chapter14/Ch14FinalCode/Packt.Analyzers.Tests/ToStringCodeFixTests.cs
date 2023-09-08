using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using RoslynTestKit;

namespace Packt.Analyzers.Tests; 

public class ToStringCodeFixTests : CodeFixTestFixture {
    protected override string LanguageName
        => LanguageNames.CSharp;

    protected override CodeFixProvider CreateProvider()
        => new ToStringCodeFix();

    protected override IReadOnlyCollection<DiagnosticAnalyzer> CreateAdditionalAnalyzers() 
        => new[] { new ToStringAnalyzer() };

    public const string BadCode = @"
using System;
public class [|Flight|]
{
    public string Id {get; set;}
    public string DepartAirport {get; set;}
    public string ArriveAirport {get; set;}
}";

    public const string GoodCode = @"
using System;
public class Flight
{
    public string Id {get; set;}
    public string DepartAirport {get; set;}
    public string ArriveAirport {get; set;}

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}";

    [Fact]
    public void CodeFixShouldMoveBadCodeToGood() {
        TestCodeFix(BadCode, GoodCode, ToStringAnalyzer.Rule.Id);
    }
}