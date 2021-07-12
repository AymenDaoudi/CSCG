using System.Collections.Generic;

namespace CSCG.Abstract.Entities.Methods
{
    public class MethodEntityBase
    {
        public object Method { get; protected set; }
        public string MethodName { get; }
        public AccessModifiers Modifiers { get; protected set; }
        public string ReturnType { get; set; }
        public ICollection<ParameterEntityBase> Parameters { get; set; }

        public MethodEntityBase(
            object method,
            string methodName,
            AccessModifiers modifiers
        )
        {
            Method = method;
            MethodName = methodName;
            Modifiers = modifiers;
            ReturnType = null;
            Parameters = new List<ParameterEntityBase>();
        }

        public MethodEntityBase()
        {
        }
    }
}