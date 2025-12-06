using BackEnd_S5_L5.Models.Entities;
using Microsoft.AspNetCore.Mvc;

public class ReportController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReportController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var totaleVerbali = _context.Anagrafiche
            .Select(a => new
            {
                Trasgressore = a.Cognome + " " + a.Nome,
                TotaleVerbali = _context.Verbali.Count(v => v.IdAnagraficaFk == a.IdAnagrafica)
            }).ToList();

        var totalePunti = _context.Anagrafiche
            .Select(a => new
            {
                Trasgressore = a.Cognome + " " + a.Nome,
                TotalePunti = _context.Verbali.Where(v => v.IdAnagraficaFk == a.IdAnagrafica).Sum(v => (int?)v.DecurtamentoPunti) ?? 0
            }).ToList();

        var puntiMaggiore10 = _context.Verbali
            .Where(v => v.DecurtamentoPunti > 10)
            .Select(v => new
            {
                v.Importo,
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.DecurtamentoPunti
            }).ToList();

        var importoMaggiore400 = _context.Verbali
            .Where(v => v.Importo > 400)
            .Select(v => new
            {
                v.Importo,
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.DecurtamentoPunti
            }).ToList();

        ViewBag.TotaleVerbali = totaleVerbali;
        ViewBag.TotalePunti = totalePunti;
        ViewBag.PuntiMaggiore10 = puntiMaggiore10;
        ViewBag.ImportoMaggiore400 = importoMaggiore400;

        return View();
    }
}
