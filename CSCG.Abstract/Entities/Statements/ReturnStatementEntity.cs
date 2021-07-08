using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Entities.Statements
{
    public class ReturnStatementEntity : StatementEntityBase
    {
        public ReturnStatementEntity(ExpressionEntityBase expression)
        : base(expression)
        {
        }
    }
}