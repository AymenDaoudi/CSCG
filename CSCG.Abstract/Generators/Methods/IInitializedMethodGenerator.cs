using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IInitializedMethodGenerator<TMethod, TStatement, TParameter> : IGenerator<TMethod>
        where TMethod : MethodEntityBase
        where TStatement : StatementEntityBase
        where TParameter : ParameterEntityBase
    {
        IInitializedMethodGenerator<TMethod, TStatement, TParameter> SetParameters(params TParameter[] parameters);

        IInitializedMethodGenerator<TMethod, TStatement, TParameter> SetStatements(params TStatement[] statements);
    }
}