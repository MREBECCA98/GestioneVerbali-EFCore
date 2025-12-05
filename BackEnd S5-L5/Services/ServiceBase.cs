using BackEnd_S5_L5.Models.Entities;

namespace BackEnd_S5_L5.Services
{
    public abstract class ServiceBase
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        protected ServiceBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected async Task<bool> SaveChangesAsync()
        {
            bool result = false;
            try
            {
                result = await _applicationDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
            return result;
        }

    }
}
