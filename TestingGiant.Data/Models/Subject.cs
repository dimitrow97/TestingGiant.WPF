using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Subject : IKeepDatesAndCreator
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IList<QuestionSubject> QuestionSubject { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
