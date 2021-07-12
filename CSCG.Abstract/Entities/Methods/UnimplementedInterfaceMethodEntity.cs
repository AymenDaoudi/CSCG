using System;

namespace CSCG.Abstract.Entities.Methods
{
    public class UnimplementedInterfaceMethodEntity : MethodEntityBase
    {
        private static readonly Lazy<AccessModifiers> _modifiers = new Lazy<AccessModifiers>(() => AccessModifiers.None);

        public new static AccessModifiers Modifiers
        {
            get
            {
                return _modifiers.Value;
            }
        }

        public UnimplementedInterfaceMethodEntity(object method, string methodName)
        : base(method, methodName, Modifiers)
        {
        }

        public UnimplementedInterfaceMethodEntity()
        {
        }
    }
}