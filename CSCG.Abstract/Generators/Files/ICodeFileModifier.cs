using System.Threading.Tasks;
using CSCG.Abstract.Entities.Statements;

namespace CSCG.Abstract.Generators.Files
{
    public interface ICodeFileModifier
    {
        Task ReplaceReturnStatementOfMethodOfClassAsync(
            string filePath,
            string className,
            string methodName,
            StatementEntityBase newRturnStatement
        );

        Task AddStatementToMethodOfClassAsync(
            string filePath,
            string className,
            string methodName,
            StatementEntityBase statement
        );
    }
}