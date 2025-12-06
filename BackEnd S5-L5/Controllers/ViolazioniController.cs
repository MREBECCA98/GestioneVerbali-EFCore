using BackEnd_S5_L5.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_S5_L5.Controllers
{
    public class ViolazioniController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<TipoViolazione>());
        }
    }
}
