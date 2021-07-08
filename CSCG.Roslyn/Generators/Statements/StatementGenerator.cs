using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Generators.Statements;

namespace CSCG.Roslyn.Generators.Statements
{
    public class StatementGenerator : IStatementGenerator<StatementEntityBase, ExpressionEntityBase>
    {
        public StatementEntityBase Generate(ExpressionEntityBase expression)
        {
            StatementEntityBase returnStatement = new StatementEntityBase(expression);

            return returnStatement;
        }
    }
}