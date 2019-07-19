using RepositoryPattern_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Core.IRepositories
{
    public interface IFileRepository
    {
        IEnumerable<File> GetAll();
        File GetSingle(long fileId);
        void Add(File file);
        byte[] GetByte(long fileId);
        void Delete(File file);
    }
}
