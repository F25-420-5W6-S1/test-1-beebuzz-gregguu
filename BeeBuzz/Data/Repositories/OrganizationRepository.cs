using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationRepository : BeeBuzzGenericGenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext context, ILogger<BeeBuzzGenericGenericRepository<Beehive>> logger) : base(context, logger) { }
    
        public ApplicationUser GetOrgUsers(int orgId)
        {
            return (ApplicationUser)_dbSet.Where(user => user.OrganizationId == orgId).Include(organization => organization.User);
        }
    }
}
