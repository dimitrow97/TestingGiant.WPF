using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class UserGroup
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Group")]
        public int? GroupId { get; set; }        

        public virtual User User { get; set; }

        public virtual Group Group { get; set; }
    }
}
