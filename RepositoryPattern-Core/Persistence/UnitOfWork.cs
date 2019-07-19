using RepositoryPattern_Core.IRepositories;
using RepositoryPattern_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern_Core.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryPatternDbContext _context;
       
        public IUserFileRepository UserFileRepository { get; private set; }
        public IFileRepository FileRepository { get; private set; }



        public UnitOfWork(RepositoryPatternDbContext context)
        {
            _context = context;
            UserFileRepository = new UserFileRepository(context);
            FileRepository = new FileRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
        public void CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
