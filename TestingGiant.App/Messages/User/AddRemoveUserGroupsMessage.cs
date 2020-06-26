using TestingGiant.App.Messages.Abstraction;
using TestingGiant.App.Models;

namespace TestingGiant.App.Messages.User
{
    public class AddRemoveUserGroupsMessage : BaseMessage
    {
        public UserModel User { get; set; }
    }
}
