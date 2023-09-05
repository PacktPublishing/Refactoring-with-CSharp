using System;
using System.Linq;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Packt.Analyzers {
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ToStringAnalyzer : DiagnosticAnalyzer {

        public static readonly DiagnosticDescriptor Rule =
            new DiagnosticDescriptor(id: "CSA1001",
                title: "Override ToString()",
                messageFormat: "Override ToString on {0}",
                category: "Maintainability",
                defaultSeverity: DiagnosticSeverity.Info,
                isEnabledByDefault: true,
                description: "Override ToString to help debugging.");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
            => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext con) {
            con.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            con.EnableConcurrentExecution();
            con.RegisterSymbolAction(Analyze, SymbolKind.NamedType);
        }

        private static void Analyze(SymbolAnalysisContext con) {
            INamedTypeSymbol sym = (INamedTypeSymbol)con.Symbol;

            IMethodSymbol toString =
                sym.GetMembers()
                   .OfType<IMethodSymbol>()
                   .FirstOrDefault(m => m.Name == "ToString"
                                     && m.IsOverride
                                     && m.Parameters.Length == 0);

            if (toString == null) {
                Diagnostic diagnostic = Diagnostic.Create(Rule, sym.Locations[0], sym.Name);
                con.ReportDiagnostic(diagnostic);
            }
        }

    }
}
