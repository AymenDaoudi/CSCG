using System;

namespace CSCG.Abstract.Entities.Methods.Classes
{
    public class AbstractMethodEntity : ClassMethodEntity
    {
        private static readonly Lazy<AccessModifiers> _modifiers = new Lazy<AccessModifiers>(() => AccessModifiers.Abstract);

        public new static AccessModifiers Modifiers
        {
            get
            {
                return _modifiers.Value;
            }
        }

        public AbstractMethodEntity(
            object method,
            string methodName,
            bool isProtected = false
        )
        : base(method, methodName, Modifiers)
        {
            if (isProtected)
            {
                base.Modifiers |= AccessModifiers.Protected;
            }
            else
            {
                base.Modifiers |= AccessModifiers.Public;
            }
        }

        public AbstractMethodEntity()
        {
        }
    }
}