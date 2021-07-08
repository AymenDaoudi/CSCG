using System.Collections.Generic;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Entities.Methods
{
    public class MethodEntityBase
    {
        public object Method { get; protected set; }
        public string MethodName { get; }
        public AccessModifiers Modifiers { get; }
        public string ReturnType { get; set; }
        public ICollection<ParameterEntityBase> Parameters { get; set; }
        public ICollection<StatementEntityBase> CodeStatements { get; set; }

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
            CodeStatements = new List<StatementEntityBase>();
        }

        public MethodEntityBase()
        {
        }
    }
}