using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class ExamGroup
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Group")]
        public int? GroupId { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Exam")]
        public int? ExamId { get; set; }

        public virtual Group Group { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
