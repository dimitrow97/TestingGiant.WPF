﻿using System.Collections.Generic;

namespace TestingGiant.App.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public virtual IList<GroupModel> Groups { get; set; }

        public virtual IList<ExamModel> Exams { get; set; }
    }
}
