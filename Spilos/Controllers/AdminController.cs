using Microsoft.AspNetCore.Mvc;
using Spilos.Models;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Hosting;

namespace Spilos.Controllers
{
    public class AdminController : Controller
    {
       

        private readonly IWebHostEnvironment environment;

        public AdminController(IWebHostEnvironment _environment)
        {
            environment = _environment; 
        }

        [Route("ManagementSpilosPanel")]
        public IActionResult ManagementSpilosPanel()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult CreateActivity(string folderName)
        {
            string wwwPath = this.environment.WebRootPath;
            string contentPath = wwwPath+"\\assets\\images\\"+folderName+"-"+DateTime.Now.ToShortDateString().ToString()+"";

            string path = Path.Combine(wwwPath,contentPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                ViewBag.message = "Öncelikle etkinlik oluşturmalısınız";
            }
            return RedirectToAction("UploadPhoto",path);
          
        }

        public IActionResult UploadPhoto()
        {
            Images img = new Images();
            if (!String.IsNullOrEmpty(path))
            {
                var displayimg = path;
                DirectoryInfo di = new DirectoryInfo(displayimg);
                FileInfo[] fileInfos = di.GetFiles();
                img.FileImage = fileInfos;
            }
           
            return View(img);
        }
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile imgFile,string path)
        {
            
           
            string ext = Path.GetExtension(imgFile.FileName);
            if (ext==".jpg" || ext==".gif")
            {
                var imgSave =path;
                var stream = new FileStream(imgSave, FileMode.Create);
                await imgFile.CopyToAsync(stream);
                stream.Close();
            }

            return RedirectToAction("UploadPhoto");
        }

    }
}
