using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Generators.Namespaces
{
    public interface INamespaceGenerator<TNs, TType>
        where TNs : NamespaceEntityBase<TType>
        where TType : TypeEntityBase
    {
        IInitializedNamespaceGenerator<NamespaceEntityBase<TypeEntityBase>, TypeEntityBase> Initialize(string namespaceName);
    }
}