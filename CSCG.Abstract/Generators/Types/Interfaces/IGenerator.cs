using CSCG.Abstract.Entities.Types.Classes;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public interface IGenerator<TClass> where TClass : InterfaceEntityBase
    {
        TClass Generate();
    }
}