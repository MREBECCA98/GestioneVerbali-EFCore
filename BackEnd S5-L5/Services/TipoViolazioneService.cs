using BackEnd_S5_L5.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_S5_L5.Services
{
    public class TipoViolazioneService : ServiceBase
    {
        public TipoViolazioneService(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

    }


}
