using Microsoft.Extensions.DependencyInjection;

using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Files;
using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Methods.Interfaces;
using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Entities.Types;
using CSCG.Abstract.Entities.Types.Classes;
using CSCG.Abstract.Entities.Types.Interfaces;
using CSCG.Abstract.Generators.Expressions;
using CSCG.Abstract.Generators.Files;
using CSCG.Abstract.Generators.Methods;
using CSCG.Abstract.Generators.Modifiers;
using CSCG.Abstract.Generators.Namespaces;
using CSCG.Abstract.Generators.Types.Classes;
using CSCG.Abstract.Generators.Types.Interfaces;
using CSCG.Abstract.Generators.Statements;
using CSCG.Abstract.Repositories;
using CSCG.Roslyn.Generators.Expressions;
using CSCG.Roslyn.Generators.Files;
using CSCG.Roslyn.Generators.Mappers;
using CSCG.Roslyn.Generators.Namespaces;
using CSCG.Roslyn.Generators.Statements;
using CSCG.Roslyn.Generators.Types.Classes;
using CSCG.Roslyn.Repositories;
using CSCG.Roslyn.Generators.Methods.Classes;
using CSCG.Roslyn.Generators.Types.Interfaces;

namespace CSCG.Roslyn
{
    public static class Setup
    {
        public static IServiceCollection Services { get; }

        static Setup()
        {
            Services = new ServiceCollection()
                .AddSingleton(typeof(ICodeFileReader<CodeFileEntityBase>), typeof(CodeFileReader))
                .AddSingleton(typeof(ICodeFileGenerator<TypeEntityBase>), typeof(CodeFileGenerator))
                .AddSingleton<ICodeFileModifier, CodeFileModifier>()
                .AddSingleton(typeof(INamespaceGenerator<NamespaceEntityBase<TypeEntityBase>, TypeEntityBase>), typeof(NamespaceGenerator))
                .AddSingleton(typeof(IClassGenerator<ClassEntityBase, ClassMethodEntity>), typeof(ClassGenerator))
                .AddSingleton(typeof(IInterfaceGenerator<InterfaceEntityBase, InterfaceMethodEntity>), typeof(InterfaceGenerator))
                .AddSingleton<IMethodRepository, MethodRepository>()
                .AddSingleton<IExpressionRepository, ExpressionRepository>()
                .AddSingleton(typeof(IExtensionMethodGenerator<ExtensionMethodEntity, StatementEntityBase, ParameterEntityBase>), typeof(ExtensionMethodGenerator))
                .AddSingleton(typeof(IInstanceMethodGenerator<NonAbstractMethodEntity, StatementEntityBase, ParameterEntityBase>), typeof(InstanceMethodGenerator))
                .AddSingleton(typeof(IStatementGenerator<StatementEntityBase, ExpressionEntityBase>), typeof(StatementGenerator))
                .AddSingleton(typeof(IStatementGenerator<ReturnStatementEntity, ExpressionEntityBase>), typeof(ReturnStatementGenerator))
                .AddSingleton<IMethodInvocationExpressionGenerator, MethodInvocationExpressionGenerator>()
                .AddSingleton<IObjectExpressionGenerator, ObjectExpressionGenerator>()
                .AddSingleton<IAccessModifierMapper, AccessModifiersMapper>();
        }
    }
}