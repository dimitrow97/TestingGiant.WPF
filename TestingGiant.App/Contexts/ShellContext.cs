using TestingGiant.App.Messages;
using TestingGiant.Data.Models;

namespace TestingGiant.App.Contexts
{
    public class ShellContext
    {
        private User user;
        private BaseMessage lastMessage;

        public User User
        {
            get
            {
                return user;
            }            
        }

        public BaseMessage LastMessage
        {
            get
            {
                return lastMessage;
            }            
        }

        public void SaveLastMessage(BaseMessage message)
        {
            this.lastMessage = message;
        }

        public void SetCurrentUser(User user)
        {
            this.user = user;
        }
    }
}
