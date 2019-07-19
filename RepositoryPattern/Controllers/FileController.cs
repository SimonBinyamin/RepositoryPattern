using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_Core.Persistence;

namespace RepositoryPattern.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;


        public FileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Delete/{fileId}")]
        public void Delete(long fileId)
        {
            var file = _unitOfWork.FileRepository.GetSingle(fileId);
            _unitOfWork.FileRepository.Delete(file);
            _unitOfWork.Complete();
        }
    }
}