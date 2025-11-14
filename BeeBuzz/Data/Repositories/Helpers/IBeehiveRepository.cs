using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Repositories.Helpers
{
    /**
     * 
     * 6. Create a repo method to get all the Users for an Organization (3%)
7. Create a repo method to get all the Beehives for an Organization (3%)
     */
    public interface IBeehiveRepository : IRepositoryProvider<Beehive>
    {
        IEnumerable<Beehive> GetBeehivesByOrganization(int organizationId);
    }
}
