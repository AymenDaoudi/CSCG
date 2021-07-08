namespace CSCG.Abstract.Entities.Expressions
{
    public class ObjectExpressionEntity : ExpressionEntityBase
    {
        public string ObjectName { get; }

        public ObjectExpressionEntity(object expressionRoot, string objectName)
        : base(expressionRoot)
        {
            ObjectName = objectName;
        }
    }
}