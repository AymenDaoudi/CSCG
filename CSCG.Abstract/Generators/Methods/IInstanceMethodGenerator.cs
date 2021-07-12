using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IInstanceMethodGenerator<TMethod, TStatement, TParameter>
        where TMethod : MethodEntity
        where TStatement : StatementEntityBase
        where TParameter : ParameterEntityBase
    {
        IInitializedMethodGenerator<TMethod, TStatement, TParameter> Initialize(
            string methodName,
            string returnTypeName,
            AccessModifiers accessModifiers
        );
    }
}