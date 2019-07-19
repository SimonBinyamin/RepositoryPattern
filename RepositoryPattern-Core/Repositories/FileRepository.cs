using RepositoryPattern_BOL;
using RepositoryPattern_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace RepositoryPattern_Core.Repositories
{
    public class FileRepository : IFileRepository
    {

        private readonly RepositoryPatternDbContext _context;

        public FileRepository(RepositoryPatternDbContext context)
        {
            _context = context;
        }

        public void Add(File file)
        {
            _context.Files.Add(file);
        }

        public void Delete(File file)
        {
            _context.Files.Remove(file);
        }

        public IEnumerable<File> GetAll()
        {
            return _context.Files;
        }

        public byte[] GetByte(long fileId)
        {
            return (from b in _context.Files
                            where b.FileID == fileId
                            select b.FileByte).FirstOrDefault();
        }

        public File GetSingle(long fileId)
        {
            return (from t in _context.Files
                    where t.FileID == fileId
                    select t).FirstOrDefault();
        }
    }
}
