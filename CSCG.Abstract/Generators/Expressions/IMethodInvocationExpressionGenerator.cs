using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Generators.Expressions
{
    public interface IMethodInvocationExpressionGenerator
    {
        IInitializedMethodInvocationExpressionGenerator Initialize(
            ExpressionEntityBase parentExpression,
            string methodName,
            params string[] typeArguments
        );
    }
}