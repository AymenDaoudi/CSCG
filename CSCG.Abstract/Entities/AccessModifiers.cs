using System;

namespace CSCG.Abstract.Entities
{
    /// <summary>
    /// Type that represents possible access modifiers.
    /// Un object of this type can be used as a flag
    /// <example>
    /// This sample shows how to use <see cref="AccessModifiers"/> as a flag.
    /// <code>
    /// AccessModifiers.Public | AccessModifiers.Protected
    /// </code>
    /// </example>
    /// </summary>
    [Flags]
    public enum AccessModifiers : sbyte
    {
        None = 0,
        Private = 1,
        Public = 2,
        Protected = 4,
        Static = 8
            e
    }
}