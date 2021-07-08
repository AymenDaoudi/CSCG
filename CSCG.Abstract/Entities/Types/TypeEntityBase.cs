namespace CSCG.Abstract.Entities.Types
{
    public class TypeEntityBase
    {
        public string Name { get; }

        public object TypeRoot { get; }

        public TypeEntityBase(string name, object typeRoot)
        {
            Name = name;
            TypeRoot = typeRoot;
        }
    }
}