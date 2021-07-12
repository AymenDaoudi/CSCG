using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public interface IClassGenerator<TClass, TMethod>
        where TClass : ClassEntityBase
        where TMethod : ClassMethodEntity
    {
        IInitializedClassGenerator<TClass, TMethod> Initialize(string className, AccessModifiers accessModifiers);
    }
}