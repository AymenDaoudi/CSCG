using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IInitializedExtensionMethodGenerator<TMethod, TStatement, TParameter> : IInitializedMethodGenerator<TMethod, TStatement, TParameter>
        where TMethod : ExtensionMethodEntity
        where TStatement : StatementEntityBase
        where TParameter : ParameterEntityBase
    {
    }
}