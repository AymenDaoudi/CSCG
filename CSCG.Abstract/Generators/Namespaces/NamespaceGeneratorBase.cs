using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Generators.Namespaces
{
    public abstract class NamespaceGeneratorBase<TNamespace, TNsRoot> : IGenerator<TNamespace, TypeEntityBase> where TNamespace : NamespaceEntityBase<TypeEntityBase>
    {
        protected TNsRoot @namespace;
        protected TypeEntityBase[] members;

        public virtual TNamespace Generate()
        {
            var namespaceEntity = GenerateNamespaceEntity();

            Reset();

            return namespaceEntity;
        }

        protected abstract TNamespace GenerateNamespaceEntity();

        protected virtual void Reset()
        {
            @namespace = default;
        }
    }
}