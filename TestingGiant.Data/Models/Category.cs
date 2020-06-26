using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Category : IKeepDatesAndCreator
    {
        public Category()
        {
            this.Questions = new List<Question>();
            this.Exams = new List<Exam>();
        }

        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual IList<Question> Questions { get; set; }

        public virtual IList<Exam> Exams { get; set; }

        public int CreatorId { get; set; }               

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
