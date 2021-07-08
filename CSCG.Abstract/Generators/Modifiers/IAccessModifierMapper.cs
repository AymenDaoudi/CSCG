using CSCG.Abstract.Entities;

namespace CSCG.Abstract.Generators.Modifiers
{
    public interface IAccessModifierMapper<T>
    {
        T[] From(AccessModifiers accessModifier);

        AccessModifiers To(T[] syntaxTokens);
    }
}