using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Generators.Namespaces
{
    public interface IInitializedNamespaceGenerator<TNs, TType> : IGenerator<TNs, TType>
        where TNs : NamespaceEntityBase<TType>
        where TType : TypeEntityBase
    {
        IInitializedNamespaceGenerator<TNs, TType> SetMemebers(params TType[] members);
    }
}