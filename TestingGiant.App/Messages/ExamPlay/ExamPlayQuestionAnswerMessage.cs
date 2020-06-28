using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.ExamPlay
{
    public class ExamPlayQuestionAnswerMessage : BaseMessage
    {
        public QuestionModel Question { get; set; }

        public QuestionAnswerModel QuestionAnswer { get; set; }
    }
}
