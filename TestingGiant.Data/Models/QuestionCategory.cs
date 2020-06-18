using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingGiant.Data.Models
{
    public class QuestionCategory
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Question")]
        public int? QuestionId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Question Question { get; set; }
    }
}
