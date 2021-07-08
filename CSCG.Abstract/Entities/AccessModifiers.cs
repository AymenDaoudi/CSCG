using System;

namespace CSCG.Abstract.Entities
{
    [Flags]
    public enum AccessModifiers : sbyte
    {
        None = 0,
        Private = 1,
        Public = 2,
        Protected = 4,
        Static = 8
    }
}