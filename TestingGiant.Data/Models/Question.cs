using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    //BASE CLASS QUESTION - SingleOptionQuestion, MultipleChoiseQuestion, OpenAnswerQuestion, DragAndDropQuestion

    public class Question : IKeepDatesAndCreator
    {
        public Question()
        {
            this.Answers = new List<QuestionAnswer>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public virtual IList<QuestionAnswer> Answers { get; set; }
             
        public QuestionType QuestionType { get; set; }

        public virtual IList<QuestionCategory> QuestionCategory { get; set; }

        public virtual IList<QuestionSubject> QuestionSubject { get; set; }

        public virtual IList<ExamQuestion> ExamQuestion { get; set; }

        public decimal Points { get; set; }

        public Difficulty Difficulty { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
