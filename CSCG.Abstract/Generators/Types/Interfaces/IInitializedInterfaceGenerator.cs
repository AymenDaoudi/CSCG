using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public interface IInitializedInterfaceGenerator<TInterface, TMethod> : IGenerator<TInterface> where TInterface : InterfaceEntityBase
    {
        IInitializedInterfaceGenerator<TInterface, TMethod> SetMethods(params TMethod[] methods);
    }
}