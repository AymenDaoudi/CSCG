using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Statements
{
    public interface IStatementGenerator<TStatement, TExpression>
        where TStatement : StatementEntityBase
        where TExpression : ExpressionEntityBase
    {
        TStatement Generate(TExpression expression);
    }
}