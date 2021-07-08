using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Generators.Expressions
{
    public abstract class ExpressionGeneratorBase<TExpression, TExpressionRoot> : IGenerator<TExpression> where TExpression : ExpressionEntityBase
    {
        protected TExpressionRoot _expression;

        public TExpression Generate()
        {
            var method = GenerateExpressionEntity();

            Reset();

            return method;
        }

        protected abstract TExpression GenerateExpressionEntity();

        protected virtual void Reset()
        {
            _expression = default;
        }
    }
}