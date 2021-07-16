using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods.Interfaces;
using CSCG.Abstract.Entities.Types.Interfaces;
using CSCG.Abstract.Generators.Modifiers;
using CSCG.Abstract.Generators.Types.Interfaces;

namespace CSCG.Roslyn.Generators.Types.Interfaces
{
    public class InterfaceGenerator : IInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity>
    {
        private readonly IAccessModifierMapper _accessModifierMapper;

        public InterfaceGenerator(IAccessModifierMapper accessModifierMapper)
        {
            _accessModifierMapper = accessModifierMapper;
        }

        public IInitializedInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity> Initialize(string interfaceName, AccessModifiers modifiers)
        {
            var syntaxTokens = (SyntaxToken[])_accessModifierMapper.From(modifiers);

            var @class = SyntaxFactory
                .InterfaceDeclaration(interfaceName)
                .AddModifiers(syntaxTokens);

            var initializedClassGenerator = new InitializedInterfaceGenerator(@class);

            return initializedClassGenerator;
        }

        private class InitializedInterfaceGenerator : InterfaceGeneratorBase<InterfaceEntityBase, InterfaceDeclarationSyntax>, IInitializedInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity>
        {
            public InitializedInterfaceGenerator(InterfaceDeclarationSyntax @interface)
            {
                this.@interface = @interface;
            }

            public IInitializedInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity> ImplementInterfaces(params InterfaceEntityBase[] interfaces)
            {
                @interface = @interface.AddBaseListTypes(interfaces.Select(i => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(i.Name))).ToArray());
                return this;
            }

            public IInitializedInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity> SetMethods(params InterfaceMethodEntity[] methods)
            {
                @interface = @interface.AddMembers(methods.Select(m => (MemberDeclarationSyntax)m.Method).ToArray());
                return this;
            }

            protected override InterfaceEntityBase GenerateInterfaceEntity(InterfaceDeclarationSyntax interfaceRoot)
            {
                var interfaceEntity = new InterfaceEntityBase(
                    interfaceRoot.Identifier.ValueText,
                    interfaceRoot
                );

                return interfaceEntity;
            }
        }
    }
}