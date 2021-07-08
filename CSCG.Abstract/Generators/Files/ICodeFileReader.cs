using System.Threading.Tasks;

using CSCG.Abstract.Entities.Files;
using CSCG.Abstract.Entities.Types.Classes;

namespace CSCG.Abstract.Generators.Files
{
    public interface ICodeFileReader<T> where T : CodeFileEntityBase
    {
        Task<T> ReadAsync(string filePath);
        Task<ClassEntityBase> ReadClassAsync(string filePath, string className);
    }
}