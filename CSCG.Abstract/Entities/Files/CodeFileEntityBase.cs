namespace CSCG.Abstract.Entities.Files
{
    public class CodeFileEntityBase
    {
        public object CodeFileRoot { get; set; }

        public CodeFileEntityBase(object codeFileRoot)
        {
            CodeFileRoot = codeFileRoot;
        }
    }
}