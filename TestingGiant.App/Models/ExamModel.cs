using TestingGiant.Data.Enums;

namespace TestingGiant.App.Models
{
    public class ExamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ExamType { get; set; }

        public decimal TimeToFinishInMinutes { get; set; }

        public decimal MaximumScore { get; set; }

        public string ExamKey { get; set; }

        public string ExamPassword { get; set; }
    }
}
