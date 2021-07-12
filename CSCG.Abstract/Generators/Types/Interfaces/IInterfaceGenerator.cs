using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods.Interfaces;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public interface IInterfaceGenerator<TInterface, TMethod> 
        where TInterface : InterfaceEntityBase
        where TMethod : InterfaceMethodEntity
    {
        IInitializedInterfaceGenerator<TInterface, TMethod> Initialize(string interfaceName, AccessModifiers accessModifiers);
    }
}