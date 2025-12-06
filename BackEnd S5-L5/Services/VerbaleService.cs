using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_S5_L5.Services
{
    public class VerbaleService : ServiceBase
    {

        public VerbaleService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        //get idVerbale
        public async Task<Verbale> GetVerbaleAsync(Guid Id)
        {
            return _applicationDbContext.Verbali.FirstOrDefault(v => v.IdVerbale == Id);
        }

        //get all
        public async Task<List<Verbale>> GetAllVerbaliAsync()
        {
            return await _applicationDbContext.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .ToListAsync();
        }

        //create 
        public async Task<bool> Create(Verbale verbale)
        {
            try
            {
                await _applicationDbContext.Verbali.AddAsync(verbale);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> Update(Verbale verbale)
        {

            this._applicationDbContext.Verbali.Update(verbale);
            return this._applicationDbContext.SaveChanges() > 0;

        }

        public async Task<bool> Deleted(Verbale verbale)
        {

            this._applicationDbContext.Verbali.Remove(verbale);
            return this._applicationDbContext.SaveChanges() > 0;

        }


    }
}
