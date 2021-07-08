using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Generators.Expressions
{
    public interface IGenerator<TExpression> where TExpression : ExpressionEntityBase
    {
        TExpression Generate();
    }
}