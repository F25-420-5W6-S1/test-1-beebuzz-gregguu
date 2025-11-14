using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeBuzz.Data.Entities
{
    /*
     The BeeBuzz App should be a way to manage the bee hives.
    Usually there is at least one user that is part of an organization.
    One organization can have multiple users and the OrganizationId is mandatory and uniq id provided by the government.
    One user will have multiple bee hives to manage.
    A bee hive will have : location/ address, status (active/inactive), reason for deactivation(dead, sold)
     */
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public List<Beehive> beehives { get; set; } = new List<Beehive>();
        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; }

        public int OrganizationId { get; set; }
    }
}
