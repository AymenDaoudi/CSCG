using CSCG.Abstract.Entities;

namespace CSCG.Abstract.Generators.Modifiers
{
    public interface IAccessModifierMapper
    {
        object From(AccessModifiers accessModifier);

        AccessModifiers To(object accessModifier);
    }
}