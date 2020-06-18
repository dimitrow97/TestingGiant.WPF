﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Interfaces;

namespace TestingGiant.Data.Models
{
    public class User : IKeepDates
    {       
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; } //Hash SHA1

        public string PhoneNumber { get; set; }

        public UserRole Role { get; set; }

        public virtual IList<UserCertificate> UserCertificate { get; set; }

        public virtual IList<UserGroup> UserGroup { get; set; }

        public virtual IList<UserExam> UserExam { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? LastEditedOn { get; set; }
    }
}