using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IExtensionMethodGenerator<TMethod, TStatement, TParameter>
        where TMethod : ExtensionMethodEntity
        where TStatement : StatementEntityBase
        where TParameter : ParameterEntityBase
    {
        IInitializedMethodGenerator<TMethod, TStatement, TParameter> Initialize(
            string methodName,
            string returnTypeName,
            string extendedTypeName,
            string extendedTypeParameterName
        );
    }
}