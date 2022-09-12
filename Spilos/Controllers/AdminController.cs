using Microsoft.AspNetCore.Mvc;

namespace Spilos.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ManagementSpilosPanel()
        {
            return View();
        }
    }
}
