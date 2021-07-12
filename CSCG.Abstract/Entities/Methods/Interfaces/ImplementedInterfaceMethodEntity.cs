using System.Collections.Generic;

using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Entities.Methods.Interfaces
{
    public class ImplementedInterfaceMethodEntity : InterfaceMethodEntity
    {
        public ICollection<StatementEntityBase> CodeStatements { get; set; }

        public ImplementedInterfaceMethodEntity(object method, string methodName)
        : base(method, methodName)
        {
            CodeStatements = new List<StatementEntityBase>();
        }

        public ImplementedInterfaceMethodEntity()
        {
        }
    }
}