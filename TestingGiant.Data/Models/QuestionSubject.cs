using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class QuestionSubject
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Question")]
        public int? QuestionId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Question Question { get; set; }
    }
}
