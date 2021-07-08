using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Generators.Namespaces
{
    public interface IGenerator<TNamespace, TType>
        where TNamespace : NamespaceEntityBase<TType>
        where TType : TypeEntityBase
    {
        TNamespace Generate();
    }
}