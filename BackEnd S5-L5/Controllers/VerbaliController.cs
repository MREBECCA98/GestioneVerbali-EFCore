using BackEnd_S5_L5.Models.Entities;
using BackEnd_S5_L5.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEnd_S5_L5.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly VerbaleService _verbaleService;

        public VerbaliController(VerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }

        // Mostra tutti i verbali
        public IActionResult Index()
        {
            var verbali = _verbaleService.GetAllVerbaliAsync().Result; // chiamiamo Result invece di async/await
            return View(verbali);
        }

        // GET: crea nuovo verbale
        public IActionResult Create()
        {
            return View();
        }

        // POST: crea nuovo verbale
        [HttpPost]
        public IActionResult Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                verbale.IdVerbale = Guid.NewGuid();
                verbale.DataTrascrizioneVerbale = DateTime.Now;
                _verbaleService.Create(verbale).Wait(); // blocchiamo finché non salva
                return RedirectToAction("Index");
            }
            return View(verbale);
        }
    }
}
