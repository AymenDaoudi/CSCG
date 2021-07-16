using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Generators.Methods;
using CSCG.Abstract.Generators.Modifiers;

namespace CSCG.Roslyn.Generators.Methods.Classes
{
    public class InstanceMethodGenerator : IInstanceMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase>
    {
        private readonly IAccessModifierMapper _accessModifierMapper;

        public InstanceMethodGenerator(IAccessModifierMapper accessModifierMapper)
        {
            _accessModifierMapper = accessModifierMapper;
        }

        public IInitializedMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase> Initialize(
            string methodName,
            string returnTypeName,
            AccessModifiers modifiers
        )
        {
            var method = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(returnTypeName), methodName);

            var syntaxTokenModifiers = (SyntaxToken[])_accessModifierMapper.From(modifiers);
            method = method.AddModifiers(syntaxTokenModifiers);

            var initializedMethodGenerator = new InitializedInstanceMethodGenerator(_accessModifierMapper, method);

            return initializedMethodGenerator;
        }

        private class InitializedInstanceMethodGenerator : MethodGeneratorBase<NonAbstractMethodEntity, MethodDeclarationSyntax>, IInitializedInstanceMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase>
        {
            private readonly IAccessModifierMapper _accessModifierMapper;

            public InitializedInstanceMethodGenerator(
                IAccessModifierMapper accessModifierMapper,
                MethodDeclarationSyntax method
            )
            {
                _method = method;
                _accessModifierMapper = accessModifierMapper;
            }

            public IInitializedMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase> SetParameters(params ParameterEntityBase[] parameters)
            {
                var parameterSynatxes = parameters.Select(parameter => SyntaxFactory.Parameter(
                    new SyntaxList<AttributeListSyntax>(),
                    new SyntaxTokenList(),
                    SyntaxFactory.ParseTypeName(parameter.ParameterTypeName),
                    SyntaxFactory.Identifier(parameter.ParameterName),
                    null
                ));

                _method = _method.AddParameterListParameters(parameterSynatxes.ToArray());

                return this;
            }

            public IInitializedMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase> SetStatements(params StatementEntityBase[] statements)
            {
                //Todo: To Convert to a strategy pattern
                var statementSyntaxes = new List<StatementSyntax>();

                foreach (var statement in statements)
                {
                    if (statement is ReturnStatementEntity)
                    {
                        statementSyntaxes.Add(SyntaxFactory.ReturnStatement((ExpressionSyntax)((ReturnStatementEntity)statement).Expression.ExpressionRoot));
                    }
                }

                _method = _method.AddBodyStatements(statementSyntaxes.ToArray());

                return this;
            }

            protected override NonAbstractMethodEntity GenerateMethodEntity()
            {
                var methodEntity = new NonAbstractMethodEntity(
                    _method,
                    _method.Identifier.ValueText,
                    _accessModifierMapper.To(_method.Modifiers.ToArray())
                );

                return methodEntity;
            }
        }
    }
}