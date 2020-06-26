using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Question
{
    public class EditQuestionDisplayMessage : BaseMessage
    {
        public QuestionModel QuestionModel { get; set; }
    }
}
