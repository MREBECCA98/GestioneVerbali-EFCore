using BackEnd_S5_L5.Models.Entities;
using BackEnd_S5_L5.Services;
using Microsoft.AspNetCore.Mvc;


namespace BackEnd_S5_L5.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly VerbaleService _verbaleService;
        private readonly TrasgressoriService _trasgressoriService;
        private readonly ViolazioniService _violazioniService;

        public VerbaliController(
            VerbaleService verbaleService,
            TrasgressoriService trasgressoriService,
            ViolazioniService violazioniService)
        {
            _verbaleService = verbaleService;
            _trasgressoriService = trasgressoriService;
            _violazioniService = violazioniService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Trasgressori = await _trasgressoriService.GetAllTrasgressoriAsync();
            ViewBag.Violazioni = await _violazioniService.GetAllViolazioniAsync();

            var verbali = await _verbaleService.GetAllVerbaliAsync();
            return View(verbali);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Verbale verbale)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Trasgressori = await _trasgressoriService.GetAllTrasgressoriAsync();
                ViewBag.Violazioni = await _violazioniService.GetAllViolazioniAsync();
                return View(await _verbaleService.GetAllVerbaliAsync());
            }

            verbale.IdVerbale = Guid.NewGuid();
            verbale.DataTrascrizioneVerbale = DateTime.Now;

            verbale.Anagrafica = null;
            verbale.TipoViolazione = null;

            await _verbaleService.Create(verbale);

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var verbale = await _verbaleService.GetVerbaleAsync(id);

            ViewBag.Trasgressori = await _trasgressoriService.GetAllTrasgressoriAsync();
            ViewBag.Violazioni = await _violazioniService.GetAllViolazioniAsync();

            return View(verbale);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Verbale verbale)
        {
            verbale.Anagrafica = null;
            verbale.TipoViolazione = null;

            await _verbaleService.Update(verbale);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var verbale = await _verbaleService.GetVerbaleAsync(id);

            if (verbale != null)
                await _verbaleService.Delete(verbale);

            return RedirectToAction("Index");
        }
    }
}
