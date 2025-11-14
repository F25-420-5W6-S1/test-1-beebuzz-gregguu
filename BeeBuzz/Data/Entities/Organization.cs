using System.ComponentModel.DataAnnotations;

namespace BeeBuzz.Data.Entities
{
        /*
     The BeeBuzz App should be a way to manage the bee hives.
    Usually there is at least one user that is part of an organization.
    One organization can have multiple users and the OrganizationId is mandatory and uniq id provided by the government.
    One user will have multiple bee hives to manage.
    A bee hive will have : location/ address, status (active/inactive), reason for deactivation(dead, sold)
     */
    public class Organization
    {
        [Key]
        public required int OrganizationId { get; set; }

        public ICollection<Organization> Beehives { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }
        public ApplicationUser User { get; set; }
    }
}
