using CSCG.Abstract.Entities;
using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public interface IClassGenerator<TClass, TMethod>
        where TClass : ClassEntityBase
        where TMethod : MethodEntity
    {
        IInitializedClassGenerator<TClass, TMethod> Initialize(string className, AccessModifiers accessModifiers);
    }
}