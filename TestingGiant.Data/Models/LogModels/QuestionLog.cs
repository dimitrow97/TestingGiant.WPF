using System;
using System.Collections.Generic;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models.LogModels
{
    public class QuestionLog : ILogEntity
    {
        public QuestionLog()
        {
            this.Answers_Old = new List<QuestionAnswer>();
            this.Answers_New = new List<QuestionAnswer>();
            this.Categories_Old = new List<Category>();
            this.Categories_New = new List<Category>();
        }

        public int Id { get; set; }

        public string QuestionId { get; set; }

        public string Title_Old { get; set; }

        public string Title_New { get; set; }

        public string Description_Old { get; set; }

        public string Description_New { get; set; }

        public IList<QuestionAnswer> Answers_Old { get; set; }

        public IList<QuestionAnswer> Answers_New { get; set; }

        public QuestionType QuestionType_Old { get; set; }

        public QuestionType QuestionType_New { get; set; }

        public IList<Category> Categories_Old { get; set; }

        public IList<Category> Categories_New { get; set; }

        public IList<Subject> Subjects_Old { get; set; }

        public IList<Subject> Subjects_New { get; set; }

        public decimal Points_Old { get; set; }

        public decimal Points_New { get; set; }

        public Difficulty Difficulty_Old { get; set; }

        public Difficulty Difficulty_New { get; set; }

        public string CreatorId { get; set; }

        public User Creator { get; set; }      
        
        public string EditorId { get; set; }

        public User Editor { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
