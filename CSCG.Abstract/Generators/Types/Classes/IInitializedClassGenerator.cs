using CSCG.Abstract.Entities.Methods.Classes;
using CSCG.Abstract.Entities.Types.Classes;
using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public interface IInitializedClassGenerator<TClass, TMethod> : IGenerator<TClass>
        where TClass : ClassEntityBase
        where TMethod : ClassMethodEntity
    {
        IInitializedClassGenerator<TClass, TMethod> ImplementInterfaces(params InterfaceEntityBase[] interfaces);

        // #Todo : Take care of sealed classes later
        IInitializedClassGenerator<TClass, TMethod> ImplementClass(ClassEntityBase baseClass);

        IInitializedClassGenerator<TClass, TMethod> SetFields();

        IInitializedClassGenerator<TClass, TMethod> SetMethods(params TMethod[] methods);

        IInitializedClassGenerator<TClass, TMethod> SetProperties();
    }
}