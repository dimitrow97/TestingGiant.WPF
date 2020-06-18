using System;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class QuestionAnswer : IKeepDatesAndCreator
    {
        [Key]
        public int Id { get; set; }

        public string Answer { get; set; }

        public bool IsItCorrect { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}