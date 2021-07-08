using CSCG.Abstract.Entities.Expressions;

namespace CSCG.Abstract.Repositories
{
    public interface IExpressionRepository
    {
        TExpression AllignMethodsChaining<TExpression>(TExpression methodsInvocationExpression) where TExpression : MethodInvocationExpressionEntity;
    }
}