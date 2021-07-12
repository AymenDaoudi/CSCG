using System.Collections.Generic;

using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Entities.Methods.Classes
{
    public class NonAbstractMethodEntity : ClassMethodEntity
    {
        public ICollection<StatementEntityBase> CodeStatements { get; set; }

        public NonAbstractMethodEntity(
            object method,
            string methodName,
            AccessModifiers modifiers
        )
        : base(method, methodName, modifiers)
        {
            //Todo : Throw exception if abstract is used.
            CodeStatements = new List<StatementEntityBase>();
        }

        public NonAbstractMethodEntity()
        {
        }
    }
}