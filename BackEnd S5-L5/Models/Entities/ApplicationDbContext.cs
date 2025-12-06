using Microsoft.EntityFrameworkCore;

namespace BackEnd_S5_L5.Models.Entities

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Anagrafica> Anagrafiche { get; set; }

        public DbSet<Verbale> Verbali { get; set; }
        public DbSet<TipoViolazione> Violazioni { get; set; }


    }
}
