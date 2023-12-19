using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace Packt.Analyzers {

  [Shared]
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ToStringCodeFix))]
    public class ToStringCodeFix : CodeFixProvider {
        public override ImmutableArray<string> FixableDiagnosticIds
            => ImmutableArray.Create(ToStringAnalyzer.Rule.Id);

        public override FixAllProvider GetFixAllProvider()
            => WellKnownFixAllProviders.BatchFixer;

        public async override Task RegisterCodeFixesAsync(CodeFixContext context) {
            Document doc = context.Document;
            Diagnostic diagnostic = context.Diagnostics.First();
            TextSpan span = diagnostic.Location.SourceSpan;

            SyntaxNode root = await doc
                .GetSyntaxRootAsync(context.CancellationToken)
                .ConfigureAwait(false);

            // Find the type declaration identified by the diagnostic.
            TypeDeclarationSyntax typeDec =
                root.FindToken(span.Start)
                    .Parent
                    .AncestorsAndSelf()
                    .OfType<TypeDeclarationSyntax>()
                    .First();

            CodeAction fix = CodeAction.Create(
                title: "Override ToString",
                createChangedDocument: c => FixAsync(doc, typeDec)
            );

            context.RegisterCodeFix(fix, diagnostic);
        }

        Task<Document> FixAsync(Document doc, TypeDeclarationSyntax typeDec) {
            // Add a new override of ToString that throws a NotImplementedException

            const string exType = "NotImplementedException";
            IdentifierNameSyntax exId = SyntaxFactory.IdentifierName(exType);

            BlockSyntax methodBody = SyntaxFactory.Block(
                SyntaxFactory.ThrowStatement(
                    SyntaxFactory.ObjectCreationExpression(exId)
                                 .WithArgumentList(SyntaxFactory.ArgumentList())
                )
            );

            SyntaxToken[] modifiers = new SyntaxToken[] {
                SyntaxFactory.Token(SyntaxKind.PublicKeyword),
                SyntaxFactory.Token(SyntaxKind.OverrideKeyword)
            };

            SyntaxToken returnType = SyntaxFactory.Token(SyntaxKind.StringKeyword);
            MethodDeclarationSyntax newMethod = SyntaxFactory.MethodDeclaration(
                SyntaxFactory.PredefinedType(returnType),
                SyntaxFactory.Identifier("ToString"))
                .WithModifiers(SyntaxFactory.TokenList(modifiers))
                .WithBody(methodBody);

            // Mutate the existing type declaration with the new method, then replace the Type in a copy of the document and then return that document
            TypeDeclarationSyntax newType = typeDec.AddMembers(newMethod);
            SyntaxNode root = typeDec.SyntaxTree.GetRoot();
            SyntaxNode newRoot = root.ReplaceNode(typeDec, newType);
            Document newDoc = doc.WithSyntaxRoot(newRoot);

            return Task.FromResult(newDoc);
        }
    }
}
