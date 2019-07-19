using RepositoryPattern_Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryPattern_Core.Persistence
{
    public interface IUnitOfWork
    {
        IUserFileRepository UserFileRepository { get; }
        IFileRepository FileRepository { get; }
        void Complete();
        void CompleteAsync();
    }
}
