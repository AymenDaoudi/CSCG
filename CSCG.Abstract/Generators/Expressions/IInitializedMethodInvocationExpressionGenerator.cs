using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Generators.Expressions
{
    public interface IInitializedMethodInvocationExpressionGenerator : IInitializedExpressionGenerator<MethodInvocationExpressionEntity>
    {
        IInitializedMethodInvocationExpressionGenerator ChainMethodInvocation(string methodName, params string[] typeArguments);
    }
}