using CSCG.Abstract.Entities.Methods.Interfaces;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public interface IInitializedInterfaceGenerator<TInterface, TMethod> : IGenerator<TInterface> 
        where TInterface : InterfaceEntityBase
        where TMethod : InterfaceMethodEntity
    {
        IInitializedInterfaceGenerator<TInterface, TMethod> SetMethods(params TMethod[] methods);
    }
}