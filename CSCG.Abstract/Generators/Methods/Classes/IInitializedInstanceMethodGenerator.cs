using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IInitializedInstanceMethodGenerator<TMethod, TStatement, TParameter> : IInitializedMethodGenerator<TMethod, TStatement, TParameter>
        where TMethod : NonAbstractMethodEntity
        where TStatement : StatementEntityBase
        where TParameter : ParameterEntityBase
    {
    }
}