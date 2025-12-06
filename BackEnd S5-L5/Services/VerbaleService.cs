using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackEnd_S5_L5.Services
{
    public class VerbaleService : ServiceBase
    {
        public VerbaleService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        // Get 
        public async Task<Verbale> GetVerbaleAsync(Guid id)
        {
            return await _applicationDbContext.Verbali.Include(v => v.Anagrafica).Include(v => v.TipoViolazione).FirstOrDefaultAsync(v => v.IdVerbale == id);
        }

        // Get all
        public async Task<List<Verbale>> GetAllVerbaliAsync()
        {
            return await _applicationDbContext.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .ToListAsync();
        }

        // Create
        public async Task<bool> Create(Verbale verbale)
        {
            try
            {
                await _applicationDbContext.Verbali.AddAsync(verbale);
                return await _applicationDbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        // Update
        public async Task<bool> Update(Verbale verbale)
        {
            _applicationDbContext.Verbali.Update(verbale);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        // Delete
        public async Task<bool> Delete(Verbale verbale)
        {
            _applicationDbContext.Verbali.Remove(verbale);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
