using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Hosting;

namespace Spilos.Controllers
{
    public class AdminController : Controller
    {
       

        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment; 
        }

        [Route("ManagementSpilosPanel")]
        public IActionResult ManagementSpilosPanel()
        {
            return View();
        }

        public IActionResult UploadPhoto()
        {
            return View();
        }
    }
}
