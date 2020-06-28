using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.ExamPlay
{
    public class PlayExamMessage : BaseMessage
    {
        public ExamModel Exam { get; set; }
    }
}
