using BackEnd_S5_L5.Models.Entities;
using BackEnd_S5_L5.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd_S5_L5.Controllers
{
    public class TrasgressoriController : Controller
    {
        private readonly TrasgressoriService _trasgressoriService;

        public TrasgressoriController(TrasgressoriService trasgressoriService)
        {
            _trasgressoriService = trasgressoriService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trasgressori = await _trasgressoriService.GetAllTrasgressoriAsync();
            return View(trasgressori);
        }


        [HttpPost]
        public async Task<IActionResult> Index(Anagrafica trasgressore)
        {
            trasgressore.IdAnagrafica = Guid.NewGuid();
            bool isCreated = await _trasgressoriService.Create(trasgressore);

            var trasgressori = await _trasgressoriService.GetAllTrasgressoriAsync();
            return View(trasgressori);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var trasgressore = await _trasgressoriService.GetTrasgressoreAsync(id);
            if (trasgressore == null)
                return NotFound();

            return View(trasgressore);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Anagrafica trasgressore)
        {
            if (trasgressore.IdAnagrafica == Guid.Empty)
                return BadRequest("ID non valido.");

            var trasgressoreId = await _trasgressoriService.GetTrasgressoreAsync(trasgressore.IdAnagrafica);
            if (trasgressoreId == null)
                return NotFound();

            trasgressoreId.Cognome = trasgressore.Cognome;
            trasgressoreId.Nome = trasgressore.Nome;
            trasgressoreId.Indirizzo = trasgressore.Indirizzo;
            trasgressoreId.Citta = trasgressore.Citta;
            trasgressoreId.Cap = trasgressore.Cap;
            trasgressoreId.CodiceFiscale = trasgressore.CodiceFiscale;

            bool updated = await _trasgressoriService.Update(trasgressoreId);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var trasgressore = await _trasgressoriService.GetTrasgressoreAsync(id);
            if (trasgressore == null)
                return NotFound();

            bool result = await _trasgressoriService.Delete(trasgressore);

            return RedirectToAction("Index");
        }
    }
}
