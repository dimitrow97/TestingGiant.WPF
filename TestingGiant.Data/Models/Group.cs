using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Group : IKeepDatesAndCreator
    {
        public Group()
        {
            this.Users = new List<User>();
            this.Exams = new List<Exam>();
        }

        [Key]
        public int Id { get; set; }

        public string GroupName { get; set; }

        public virtual IList<User> Users { get; set; }

        public virtual IList<Exam> Exams { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
