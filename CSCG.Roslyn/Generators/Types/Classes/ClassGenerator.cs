using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Types.Classes;
using CSCG.Abstract.Generators.Modifiers;
using CSCG.Abstract.Generators.Types.Classes;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Roslyn.Generators.Types.Classes
{
    public class ClassGenerator : IClassGenerator<ClassEntityBase, ClassMethodEntity>
    {
        private readonly IAccessModifierMapper<SyntaxToken> _accessModifierMapper;

        public ClassGenerator(IAccessModifierMapper<SyntaxToken> accessModifierMapper)
        {
            _accessModifierMapper = accessModifierMapper;
        }

        public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> Initialize(string className, AccessModifiers modifiers)
        {
            var syntaxTokens = _accessModifierMapper.From(modifiers);

            var @class = SyntaxFactory
                .ClassDeclaration(className)
                .AddModifiers(syntaxTokens);

            var initializedClassGenerator = new InitializedClassGenerator(@class);

            return initializedClassGenerator;
        }

        private class InitializedClassGenerator : ClassGeneratorBase<ClassEntityBase, ClassDeclarationSyntax>, IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity>
        {
            public InitializedClassGenerator(ClassDeclarationSyntax @class)
            {
                this.@class = @class;
            }

            public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> ImplementInterfaces(params InterfaceEntityBase[] interfaces)
            {
                @class = @class.AddBaseListTypes(interfaces.Select(i => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(i.Name))).ToArray());
                return this;
            }

            public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> ImplementClass(ClassEntityBase baseClass)
            {
                @class = @class.AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(baseClass.Name)));
                return this;
            }

            public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> SetFields()
            {
                //@class.Members.AddRange(new CodeTypeMemberCollection(fields.ToArray<CodeTypeMember>()));
                return this;
            }

            public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> SetProperties()
            {
                //@class.Members.AddRange(new CodeTypeMemberCollection(properties.ToArray<CodeTypeMember>()));
                return this;
            }

            public IInitializedClassGenerator<ClassEntityBase, ClassMethodEntity> SetMethods(params ClassMethodEntity[] methods)
            {
                @class = @class.AddMembers(methods.Select(m => (MemberDeclarationSyntax)m.Method).ToArray());
                return this;
            }

            protected override ClassEntityBase GenerateClassEntity(ClassDeclarationSyntax classRoot)
            {
                var classEntity = new ClassEntityBase(
                    classRoot.Identifier.ValueText,
                    classRoot
                );

                return classEntity;
            }
        }
    }
}