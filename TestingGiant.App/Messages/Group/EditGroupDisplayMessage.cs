using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.Group
{
    public class EditGroupDisplayMessage : BaseMessage
    {
        public GroupModel GroupModel { get; set; }
    }
}
