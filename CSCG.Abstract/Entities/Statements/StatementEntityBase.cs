using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Entities.Statements
{
    public class StatementEntityBase
    {
        public ExpressionEntityBase Expression { get; }

        public StatementEntityBase(ExpressionEntityBase expression)
        {
            Expression = expression;
        }
    }
}