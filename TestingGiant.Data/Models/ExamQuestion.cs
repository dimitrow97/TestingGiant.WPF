using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class ExamQuestion
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Exam")]
        public int? ExamId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Question")]
        public int? QuestionId { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual Question Question { get; set; }
    }
}
