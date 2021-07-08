using CSCG.Abstract.Entities.Namespaces;
using CSCG.Abstract.Entities.Types;

namespace CSCG.Abstract.Generators.Files
{
    public interface ICodeFileGenerator<TType> where TType : TypeEntityBase
    {
        void CreateFile(
            string filePath,
            NamespaceEntityBase<TType> namespaceEntity,
            params string[] usings
        );
    }
}