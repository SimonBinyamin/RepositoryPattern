using RepositoryPattern_BOL;
using RepositoryPattern_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryPattern_Core.Repositories
{
    public class UserFileRepository : IUserFileRepository
    {
        private readonly RepositoryPatternDbContext _context;

        public UserFileRepository(RepositoryPatternDbContext context)
        {
            _context = context;
        }

        public void Add(UserFile userFile)
        {
            _context.UserFiles.Add(userFile);
        }

        public IEnumerable<UserFile> GetAll()
        {
            return _context.UserFiles;
        }

        public IEnumerable<UserFile> GetAll(string username)
        {

            return (from uf in _context.UserFiles
                    where uf.ApplicationUser.UserName == username
                    select uf);
        }

        public UserFile GetSingle(long fileId)
        {

            return (from uf in _context.UserFiles
                    where uf.FileID == fileId
                    select uf).FirstOrDefault();
        }
    }
}
