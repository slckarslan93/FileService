using FileService.Models;
using FileService.Models.Data.EF;
using FileService.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileService.Controllers
{
    public class HomeController : Controller
    {
        private string uploadPath = @"uploads\\file\\projectFile";
        private readonly FileServiceDbContext _dbContext;

        public HomeController(FileServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var files = _dbContext.FileEntities.OrderByDescending(x => x.Created).ToList();
            return View(files);
        }

        public IActionResult AddFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFile(FileEntity model, IFormFile file)
        {
            if (file != null)
            {
                model.Path = FileService.UploadFormFile(uploadPath, file);

                model.Updated = DateTime.Now;
                _dbContext.Add(model);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteFile(int id)
        {
            var file = _dbContext.FileEntities.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(file.Path))
            {
                FileService.DeleteFile(string.Format("wwwroot/{0}", file.Path));
            }
            _dbContext.Remove(file);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}