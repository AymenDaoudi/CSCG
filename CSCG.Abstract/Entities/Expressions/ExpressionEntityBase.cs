namespace CSCG.Abstract.Entities.Expressions
{
    public class ExpressionEntityBase
    {
        public object ExpressionRoot { get; }

        public ExpressionEntityBase(object expressionRoot)
        {
            ExpressionRoot = expressionRoot;
        }
    }
}