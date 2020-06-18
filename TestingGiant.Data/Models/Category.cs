using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Category : IKeepDatesAndCreator
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual IList<QuestionCategory> QuestionCategory { get; set; }

        public virtual IList<ExamCategory> ExamCategory { get; set; }

        public int CreatorId { get; set; }               

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
