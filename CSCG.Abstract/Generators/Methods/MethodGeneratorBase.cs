using CSCG.Abstract.Entities.Methods;

namespace CSCG.Abstract.Generators.Methods
{
    public abstract class MethodGeneratorBase<TMethod, TMethodRoot> : IGenerator<TMethod> where TMethod : MethodEntityBase
    {
        protected TMethodRoot _method;

        public TMethod Generate()
        {
            var method = GenerateMethodEntity();

            Reset();

            return method;
        }

        protected abstract TMethod GenerateMethodEntity();

        protected virtual void Reset()
        {
            _method = default;
        }
    }
}