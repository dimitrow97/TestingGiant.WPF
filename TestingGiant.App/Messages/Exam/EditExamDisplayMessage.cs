using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Exam
{
    public class EditExamDisplayMessage : BaseMessage
    {
        public ExamModel Exam { get; set; }
    }
}
