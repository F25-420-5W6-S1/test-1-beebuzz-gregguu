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
    public class Beehive
    {
        [Key]
        public int BeehiveId { get; set; }
        public string BeehiveAddress { get; set; }
        public bool BeehiveStatus { get; set; }
        public string BeehiveDeactivationReason { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public int UserId { get; set; }

        public ICollection<Organization> Organizations { get; set; }
    }
}
