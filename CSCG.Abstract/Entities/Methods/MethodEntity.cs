using System.Collections.Generic;

using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Entities.Methods
{
    public class MethodEntity : MethodEntityBase
    {
        public ICollection<StatementEntityBase> CodeStatements { get; set; }

        public MethodEntity(
            object method,
            string methodName,
            AccessModifiers modifiers
        )
        : base(method, methodName, modifiers)
        {
            CodeStatements = new List<StatementEntityBase>();
        }

        public MethodEntity()
        {
        }
    }
}