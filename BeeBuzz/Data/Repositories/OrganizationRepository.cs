using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationRepository : BeeBuzzGenericGenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext context, ILogger<BeeBuzzGenericGenericRepository<Beehive>> logger) : base(context, logger) { }
    
        public User GetOrgUsers(int orgId)
        {
            return (User)_dbSet.Where(user => user.OrganizationId == orgId).Include(organization => organization.User);
        }
    }
}
