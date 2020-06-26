using TestingGiant.Data.Enums;

namespace TestingGiant.App.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string QuestionType { get; set; }

        public decimal Points { get; set; }

        public string Difficulty { get; set; }
    }
}
