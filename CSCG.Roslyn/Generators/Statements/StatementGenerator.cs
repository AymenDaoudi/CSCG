using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Generators.Statements;

namespace CSCG.Roslyn.Generators.Statements
{
    public class StatementGenerator : IStatementGenerator<StatementEntityBase, ExpressionEntityBase>
    {
        public StatementEntityBase Generate(ExpressionEntityBase expression)
        {
            var statement = new StatementEntityBase(expression);

            return statement;
        }
    }
}