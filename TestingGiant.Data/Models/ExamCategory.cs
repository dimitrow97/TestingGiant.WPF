using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class ExamCategory
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Exam")]
        public int? ExamId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
