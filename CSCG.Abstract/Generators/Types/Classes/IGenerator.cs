using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public interface IGenerator<TClass> where TClass : ClassEntityBase
    {
        TClass Generate();
    }
}