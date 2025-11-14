using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Repositories.Helpers;

namespace BeeBuzz.Data.Repositories
{

    /*
     6. Create a repo method to get all the Users for an Organization (3%)
7. Create a repo method to get all the Beehives for an Organization (3%)
     */
    public class UserRepository : BeeBuzzGenericGenericRepository<User>, IOrganizationRepository
    {
        public UserRepository(ApplicationDbContext context, ILogger<BeeBuzzGenericGenericRepository<User>> logger) : base(context, logger) { }
    }
}
