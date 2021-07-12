using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public interface IInterfaceGenerator<TInterface> where TInterface : InterfaceEntityBase
    {
        IInterfaceGenerator<TInterface> Initialize(string interfaceName, AccessModifiers accessModifiers);
    }
}