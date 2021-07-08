using System.IO;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using CSCG.Abstract.Entities.Types;
using CSCG.Abstract.Generators.Files;
using CSCG.Abstract.Entities.Namespaces;

namespace CSCG.Roslyn.Generators.Files
{
    public class CodeFileGenerator : ICodeFileGenerator<TypeEntityBase>
    {
        public CodeFileGenerator()
        {

        }

        public void CreateFile(
            string filePath,
            NamespaceEntityBase<TypeEntityBase> namespaceEntity,
            params string[] usings
        )
        {
            var compilationUnit = SyntaxFactory.CompilationUnit(
                new SyntaxList<ExternAliasDirectiveSyntax>(),
                new SyntaxList<UsingDirectiveSyntax>(usings.Select(@using => SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(@using)))),
                new SyntaxList<AttributeListSyntax>(),
                new SyntaxList<MemberDeclarationSyntax>((NamespaceDeclarationSyntax)namespaceEntity.NamespaceRoot));

            using (FileStream fs = File.Create(filePath))
            {
                using (StreamWriter sourceWriter = new StreamWriter(fs))
                {
                    compilationUnit.NormalizeWhitespace().WriteTo(sourceWriter);
                }
            }
        }
    }
}