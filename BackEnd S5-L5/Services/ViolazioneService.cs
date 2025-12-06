using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_S5_L5.Services
{
    public class ViolazioniService : ServiceBase
    {
        public ViolazioniService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        // Get 
        public async Task<TipoViolazione> GetViolazioneAsync(Guid id)
        {
            return await _applicationDbContext.TipoViolazioni.Include(v => v.Verbali).FirstOrDefaultAsync(v => v.IdViolazione == id);
        }

        // Get all
        public async Task<List<TipoViolazione>> GetAllViolazioniAsync()
        {
            return await _applicationDbContext.TipoViolazioni.Include(v => v.Verbali)
                .ToListAsync();
        }


        // Create
        public async Task<bool> Create(TipoViolazione violazione)
        {
            try
            {
                await _applicationDbContext.TipoViolazioni.AddAsync(violazione);
                return await _applicationDbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        // Update
        public async Task<bool> Update(TipoViolazione violazione)
        {
            _applicationDbContext.TipoViolazioni.Update(violazione);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        // Delete
        public async Task<bool> Delete(TipoViolazione violazione)
        {
            _applicationDbContext.TipoViolazioni.Remove(violazione);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
