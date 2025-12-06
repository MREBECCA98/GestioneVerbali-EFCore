using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_S5_L5.Services
{
    public class ViolazioniService : ServiceBase
    {
        public ViolazioniService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        // Get violazione per Id
        public async Task<TipoViolazione> GetViolazioneAsync(Guid id)
        {
            return await _applicationDbContext.Violazioni
                .Include(v => v.Verbali)
                .FirstOrDefaultAsync(v => v.IdViolazione == id);
        }

        // Get tutte le violazioni
        public async Task<List<TipoViolazione>> GetAllViolazioniAsync()
        {
            return await _applicationDbContext.Violazioni
                .Include(v => v.Verbali)
                .ToListAsync();
        }

        // Create
        public async Task<bool> Create(TipoViolazione violazione)
        {
            try
            {
                await _applicationDbContext.Violazioni.AddAsync(violazione);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Update
        public async Task<bool> Update(TipoViolazione violazione)
        {
            _applicationDbContext.Violazioni.Update(violazione);
            return _applicationDbContext.SaveChanges() > 0;
        }

        // Delete
        public async Task<bool> Delete(TipoViolazione violazione)
        {
            _applicationDbContext.Violazioni.Remove(violazione);
            return _applicationDbContext.SaveChanges() > 0;
        }
    }
}
