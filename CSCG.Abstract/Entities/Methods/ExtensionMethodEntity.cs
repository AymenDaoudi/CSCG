using System;

namespace CSCG.Abstract.Entities.Methods
{
    public class ExtensionMethodEntity : MethodEntityBase
    {
        public string ExtendedTypeName { get; }
        public string ExtendedTypeParameterName { get; }

        private static readonly Lazy<AccessModifiers> _modifiers = new Lazy<AccessModifiers>(() => AccessModifiers.Public | AccessModifiers.Static);

        public new static AccessModifiers Modifiers
        {
            get
            {
                return _modifiers.Value;
            }
        }

        public ExtensionMethodEntity(
            object methodRoot,
            string methodName,
            string extendedTypeName,
            string extendedTypeParameterName
        )
        : base(methodRoot, methodName, Modifiers)
        {
            Method = methodRoot;
            ExtendedTypeName = extendedTypeName;
            ExtendedTypeParameterName = extendedTypeParameterName;
        }

        public ExtensionMethodEntity()
        {
        }
    }
}