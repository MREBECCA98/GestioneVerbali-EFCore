using Microsoft.AspNetCore.Mvc;

namespace BackEnd_S5_L5.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
