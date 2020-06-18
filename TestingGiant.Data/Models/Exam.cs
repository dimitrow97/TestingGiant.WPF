using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Exam : IKeepDatesAndCreator
    {
        [Key]
        public int Id { get; set; }

        public virtual IList<QuestionCategory> QuestionCategory { get; set; }

        public ExamType ExamType { get; set; }

        public decimal TimeToFinishInMinutes { get; set; }

        public decimal MaximumScore { get; set; }

        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual IList<ExamCategory> ExamCategory { get; set; }

        public virtual IList<ExamGroup> ExamGroup { get; set; }

        public virtual IList<ExamQuestion> ExamQuestion { get; set; }

        public string ExamKey { get; set; }

        public string ExamPassword { get; set; }

        public virtual IList<UserExam> UserExam { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
