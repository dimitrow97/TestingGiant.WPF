using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class UserCertificate
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Certificate")]
        public int? CertificateId { get; set; }

        public virtual User User { get; set; }

        public virtual Certificate Certificate { get; set; }
    }
}
