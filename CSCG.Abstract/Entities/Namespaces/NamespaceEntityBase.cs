using System.Collections.Generic;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Entities.Namespaces
{
    public class NamespaceEntityBase<TType> where TType : TypeEntityBase
    {
        public string Name { get; }
        public IEnumerable<TType> Member { get; }
        public object NamespaceRoot { get; }

        public NamespaceEntityBase(string name, object namespaceRoot, IEnumerable<TType> member)
        {
            Name = name;
            NamespaceRoot = namespaceRoot;
            Member = member;
        }
    }
}