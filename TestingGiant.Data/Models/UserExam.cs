using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class UserExam
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Exam")]
        public int? ExamId { get; set; }

        public virtual User User { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
