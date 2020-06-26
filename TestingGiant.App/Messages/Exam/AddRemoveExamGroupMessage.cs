using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Exam
{
    public class AddRemoveExamGroupMessage : BaseMessage
    {
        public ExamModel Exam { get; set; }
    }
}
