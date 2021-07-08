using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Generators.Expressions
{
    public interface IInitializedExpressionGenerator<TExpression> : IGenerator<TExpression> where TExpression : ExpressionEntityBase
    {
    }
}