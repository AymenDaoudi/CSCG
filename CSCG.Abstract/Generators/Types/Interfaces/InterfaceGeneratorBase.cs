using CSCG.Abstract.Entities.Types.Interfaces;

namespace CSCG.Abstract.Generators.Types.Interfaces
{
    public abstract class InterfaceGeneratorBase<TInterface, TInterfaceRoot> : IGenerator<TInterface> where TInterface : InterfaceEntityBase
    {
        protected TInterfaceRoot @interface;

        public virtual TInterface Generate()
        {
            var generatedInterface = Reset();

            var classEntity = GenerateInterfaceEntity(generatedInterface);

            return classEntity;
        }

        protected abstract TInterface GenerateInterfaceEntity(TInterfaceRoot interfaceRoot);

        protected virtual TInterfaceRoot Reset()
        {
            var generatedInterface = default(TInterfaceRoot);
            generatedInterface = @interface;

            @interface = default;

            return generatedInterface;
        }
    }
}