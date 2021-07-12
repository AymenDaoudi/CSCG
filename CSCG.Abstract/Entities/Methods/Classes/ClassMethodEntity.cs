namespace CSCG.Abstract.Entities.Methods.Classes
{
    public class ClassMethodEntity : MethodEntityBase
    {
        public ClassMethodEntity(
            object method,
            string methodName,
            AccessModifiers modifiers
        )
        : base(method, methodName, modifiers)
        {
        }

        public ClassMethodEntity()
        {
        }
    }
}