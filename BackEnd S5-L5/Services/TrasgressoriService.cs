using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd_S5_L5.Services
{
    public class TrasgressoriService : ServiceBase
    {
        public TrasgressoriService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        // Get 
        public async Task<Anagrafica> GetTrasgressoreAsync(Guid id)
        {
            return await _applicationDbContext.Anagrafiche
          .Include(a => a.Verbali)
          .FirstOrDefaultAsync(a => a.IdAnagrafica == id);
        }

        // Get all
        public async Task<List<Anagrafica>> GetAllTrasgressoriAsync()
        {
            return await _applicationDbContext.Anagrafiche
          .Include(a => a.Verbali)
          .ToListAsync();
        }

        // Create
        public async Task<bool> Create(Anagrafica trasgressore)
        {
            await _applicationDbContext.Anagrafiche.AddAsync(trasgressore);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        // Update
        public async Task<bool> Update(Anagrafica trasgressore)
        {
            _applicationDbContext.Anagrafiche.Update(trasgressore);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        // Delete
        public async Task<bool> Delete(Anagrafica trasgressore)
        {
            _applicationDbContext.Anagrafiche.Remove(trasgressore);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
