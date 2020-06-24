using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class Group : IKeepDatesAndCreator
    {      
        [Key]
        public int Id { get; set; }

        public string GroupName { get; set; }

        public virtual IList<UserGroup> UserGroup { get; set; }

        public virtual IList<ExamGroup> ExamGroup { get; set; }

        public int CreatorId { get; set; }

        public DateTime? LastEditedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
