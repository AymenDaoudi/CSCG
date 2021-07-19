using CSCG.Abstract.Entities.Expressions;
using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Generators.Statements;

namespace CSCG.Roslyn.Generators.Statements
{
    public class ReturnStatementGenerator : IStatementGenerator<ReturnStatementEntity, ExpressionEntityBase>
    {
        public ReturnStatementEntity Generate(ExpressionEntityBase expression)
        {
            var returnStatement = new ReturnStatementEntity(expression);

            return returnStatement;
        }
    }
}