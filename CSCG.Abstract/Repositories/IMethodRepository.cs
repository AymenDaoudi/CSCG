using CSCG.Abstract.Entities.Statements;
using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Repositories
{
    public interface IMethodRepository
    {
        StatementEntityBase GetReturnStatement(ClassEntityBase @class, string methodName);
    }
}