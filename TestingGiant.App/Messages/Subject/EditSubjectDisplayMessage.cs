using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Subject
{
    public class EditSubjectDisplayMessage : BaseMessage
    {
        public SubjectModel SubjectModel { get; set; }
    }
}
