using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Types.Classes
{
    public abstract class ClassGeneratorBase<TClass, TClassRoot> : IGenerator<TClass> where TClass : ClassEntityBase
    {
        protected TClassRoot @class;

        public virtual TClass Generate()
        {
            var generatedClass = Reset();

            var classEntity = GenerateClassEntity(generatedClass);

            return classEntity;
        }

        protected abstract TClass GenerateClassEntity(TClassRoot classRoot);

        protected virtual TClassRoot Reset()
        {
            var generatedClass = default(TClassRoot);
            generatedClass = @class;

            @class = default;

            return generatedClass;
        }
    }
}