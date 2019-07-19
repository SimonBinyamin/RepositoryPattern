using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern_BOL;
using RepositoryPattern_Core.Persistence;
using File = RepositoryPattern_BOL.File;

namespace RepositoryPattern.Controllers
{
    [Route("[controller]")]
    public class UserFileController : Controller
    {
        public Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserFileController(IHostingEnvironment hostingEnvironment, IUnitOfWork unitOfWork,
                                  UserManager<ApplicationUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [Route("[action]")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userFiles =
                    from t in _unitOfWork.UserFileRepository.GetAll(User.Identity.Name)
                    select t;
                return View(userFiles);
            }

            return View();

        }



        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(FileView model)
        {
            //if (User.Identity.IsAuthenticated)
            // {
            await CreateAsync(model);
            return RedirectToAction("Index");
            // }
            //return View();
        }


        public async Task CreateAsync(FileView model)
        {
            DateTime today = DateTime.Now;
            File fileDoc = new File()
            {
                Date = today,
                Name = model.File.FileName,
                Type = model.File.ContentType,
                Size = (double)model.File.Length == 0 ? 0 : (double)model.File.Length / 1000000
            };

            using (var ms = new MemoryStream())
            {
                model.File.CopyTo(ms);
                var fileBytes = ms.ToArray();
                fileDoc.FileByte = fileBytes;
            }

            _unitOfWork.FileRepository.Add(fileDoc);
            _unitOfWork.Complete();

            //UserFile userFile = new UserFile()
            //{
            //    File = fileDoc,
            //    ApplicationUser = await _userManager.FindByNameAsync(User.Identity.Name)
            //};

            //_unitOfWork.UserFileRepository.Add(userFile);
            //_unitOfWork.Complete();
        }


        [Route("Download/{fileId}")]
        public FileContentResult Download(long fileId)
        {
            var toBeDownloaded = _unitOfWork.FileRepository.GetSingle(fileId);

            if (User.Identity.IsAuthenticated)
            {
                byte[] file = _unitOfWork.FileRepository.GetByte(fileId);
                return File(file, toBeDownloaded.Type, toBeDownloaded.Name, true);
            }
            else
            {
                byte[] file = _unitOfWork.FileRepository.GetByte(fileId);
                return File(file, toBeDownloaded.Type, toBeDownloaded.Name, true);
            }
        }
    }
}