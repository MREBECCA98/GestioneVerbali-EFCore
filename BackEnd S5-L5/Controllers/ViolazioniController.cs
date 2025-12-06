using BackEnd_S5_L5.Models.Entities;
using BackEnd_S5_L5.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd_S5_L5.Controllers
{
    public class ViolazioniController : Controller
    {
        private readonly ViolazioniService _violazioniService;

        public ViolazioniController(ViolazioniService violazioniService)
        {
            _violazioniService = violazioniService;
        }


        public async Task<IActionResult> Index()
        {
            var violazioni = await _violazioniService.GetAllViolazioniAsync();
            return View(violazioni);
        }


        [HttpPost]
        public async Task<IActionResult> Index(TipoViolazione violazione)
        {
            violazione.IdViolazione = Guid.NewGuid();
            await _violazioniService.Create(violazione);

            var violazioni = await _violazioniService.GetAllViolazioniAsync();
            return View(violazioni);
        }


        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var violazione = await _violazioniService.GetViolazioneAsync(id);
            if (violazione == null)
                return NotFound();

            return View(violazione);
        }


        [HttpPost]
        public async Task<IActionResult> Update(TipoViolazione violazione)
        {
            if (violazione.IdViolazione == Guid.Empty)
                return BadRequest("ID non valido.");

            var existingViolazione = await _violazioniService.GetViolazioneAsync(violazione.IdViolazione);
            if (existingViolazione == null)
                return NotFound();

            existingViolazione.Descrizione = violazione.Descrizione;

            await _violazioniService.Update(existingViolazione);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var violazione = await _violazioniService.GetViolazioneAsync(id);
            if (violazione == null)
                return NotFound();

            await _violazioniService.Delete(violazione);
            return RedirectToAction("Index");
        }
    }
}
