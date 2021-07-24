using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Files;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Generators.Files;
using CSCG.Abstract.Repositories;
using static CSCG.Roslyn.Consts.Spaces;
using static CSCG.Roslyn.Consts.Spaces.Tabs;

namespace CSCG.Roslyn.Generators.Files
{
    public class CodeFileModifier : ICodeFileModifier
    {
        private readonly ICodeFileReader<CodeFileEntityBase> _codeFileReader;
        private readonly IExpressionRepository _expressionRepository;

        public CodeFileModifier(
            ICodeFileReader<CodeFileEntityBase> codeFileReader,
            IExpressionRepository expressionRepository
        )
        {
            _codeFileReader = codeFileReader;
            _expressionRepository = expressionRepository;
        }

        public async Task ReplaceReturnStatementOfMethodOfClassAsync(
            string filePath,
            string className,
            string methodName,
            StatementEntityBase newRturnStatement
        )
        {
            var codeFile = await _codeFileReader.ReadAsync(filePath);
            var codeFileRoot = codeFile.CodeFileRoot as CompilationUnitSyntax;

            var methodDeclarationSyntax = codeFileRoot
                .DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Single(c => c.Identifier.ValueText == className)
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Single(m => m.Identifier.ValueText == methodName);

            var statements = new List<StatementSyntax>();

            var returnStatement = methodDeclarationSyntax
                .DescendantNodes()
                .OfType<ReturnStatementSyntax>()
                .SingleOrDefault();

            statements.Add(returnStatement);

            var newReturnStatement = SyntaxFactory
                .ReturnStatement((ExpressionSyntax)newRturnStatement.Expression.ExpressionRoot)
                .NormalizeWhitespace()
                .WithLeadingTrivia(THREE_TABS)
                .WithTrailingTrivia(NEW_LINE);

            var invocation = newReturnStatement
                .DescendantNodes()
                .OfType<InvocationExpressionSyntax>()
                .First();

            var invocationEntity = new MethodInvocationExpressionEntity(invocation);
            var newInvocation = _expressionRepository.AllignMethodsChaining(invocationEntity);

            newReturnStatement = newReturnStatement.ReplaceNode(invocation, (InvocationExpressionSyntax)newInvocation.ExpressionRoot);

            codeFileRoot = codeFileRoot.TrackNodes(statements.Distinct());

            foreach (var statement in statements)
            {
                var currentStatement = codeFileRoot.GetCurrentNode(statement);
                codeFileRoot = codeFileRoot.ReplaceNode(currentStatement, newReturnStatement);
            }

            await SaveAsync(codeFileRoot, filePath);
        }

        public async Task AddStatementToMethodOfClassAsync(
            string filePath,
            string className,
            string methodName,
            StatementEntityBase statement
        )
        {
            var codeFile = await _codeFileReader.ReadAsync(filePath);
            var codeFileRoot = codeFile.CodeFileRoot as CompilationUnitSyntax;

            var methodDeclarationSyntax = codeFileRoot
                .DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Single(c => c.Identifier.ValueText == className)
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .Single(m => m.Identifier.ValueText == methodName);

            var lastStatementOfMethod = methodDeclarationSyntax
                .DescendantNodes()
                .OfType<StatementSyntax>()
                .Where(ex => ex.Parent.Parent == methodDeclarationSyntax) //First Parent is the BlockSyntax object contained withing the method
                .LastOrDefault();

            var newStatement = SyntaxFactory
                .ExpressionStatement((InvocationExpressionSyntax)statement.Expression.ExpressionRoot)
                .WithLeadingTrivia(new SyntaxTrivia[] { NEW_LINE }.Concat(THREE_TABS))
                .WithTrailingTrivia(NEW_LINE);

            codeFileRoot = codeFileRoot.InsertNodesAfter(lastStatementOfMethod, new SyntaxNode[] { newStatement });

            await SaveAsync(codeFileRoot, filePath);
        }

        public async Task AddUsingsAsync(
            string filePath,
            params string[] usings
        )
        {
            var codeFile = await _codeFileReader.ReadAsync(filePath);
            var codeFileRoot = codeFile.CodeFileRoot as CompilationUnitSyntax;

            var allUsings = codeFileRoot.Usings.AddRange(usings.Select(@using => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using)).NormalizeWhitespace().WithTrailingTrivia(NEW_LINE)));

            codeFileRoot = codeFileRoot.WithUsings(allUsings);

            await SaveAsync(codeFileRoot, filePath);
        }

        private Task SaveAsync(CompilationUnitSyntax code, string filePath)
        {
            return Task.Run(() =>
            {
                using (FileStream fs = File.Create(filePath))
                {
                    using (StreamWriter sourceWriter = new StreamWriter(fs))
                    {
                        code.WriteTo(sourceWriter);
                    }
                }
            });
        }
    }
}