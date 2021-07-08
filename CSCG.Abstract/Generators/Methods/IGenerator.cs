using CSCG.Abstract.Entities.Methods;

namespace CSCG.Abstract.Generators.Methods
{
    public interface IGenerator<TMethod> where TMethod : MethodEntityBase
    {
        TMethod Generate();
    }
}