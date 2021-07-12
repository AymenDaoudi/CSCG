using CSCG.Abstract.Entities.Methods;
using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public interface IInitializedClassGenerator<TClass, TMethod> : IGenerator<TClass>
        where TClass : ClassEntityBase
        where TMethod : MethodEntity
    {
        IInitializedClassGenerator<TClass, TMethod> SetFields();

        IInitializedClassGenerator<TClass, TMethod> SetMethods(params TMethod[] methods);

        IInitializedClassGenerator<TClass, TMethod> SetProperties();
    }
}