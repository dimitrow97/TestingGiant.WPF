using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Exam : IKeepDatesAndCreator
    {
        public Exam()
        {
            this.Questions = new List<Question>();
            this.Categories = new List<Category>();
            this.Groups = new List<Group>();
            this.Users = new List<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Question> Questions { get; set; }

        public ExamType ExamType { get; set; }

        public decimal TimeToFinishInMinutes { get; set; }

        public decimal MaximumScore { get; set; }

        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual IList<Category> Categories { get; set; }

        public virtual IList<Group> Groups { get; set; }        

        public string ExamKey { get; set; }

        public string ExamPassword { get; set; }

        public virtual IList<User> Users { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
