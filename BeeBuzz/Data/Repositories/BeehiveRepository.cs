using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories
{
    public class BeehiveRepository : BeeBuzzGenericGenericRepository<Beehive>, IBeehiveRepository
    {
        public BeehiveRepository(ApplicationDbContext context, ILogger<BeeBuzzGenericGenericRepository<Beehive>> logger) :base(context, logger) { }

        public IEnumerable<Beehive> GetBeehivesByOrganization(int organizationId)
        {
            throw new NotImplementedException();
        }
        //public IEnumerable<Beehive> GetBeehivesByOrganization(int organizationId)
        //{
        //    return _dbSet.Where(beehive => beehive.)
        //}
    }
}
