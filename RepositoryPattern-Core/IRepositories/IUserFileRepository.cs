using RepositoryPattern_BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern_Core.IRepositories
{
    public interface IUserFileRepository
    {
        IEnumerable<UserFile> GetAll();
        IEnumerable<UserFile> GetAll(string username);
        UserFile GetSingle(long fileId);
        void Add(UserFile userFile);

    }
}
