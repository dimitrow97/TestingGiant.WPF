using TestingGiant.App.Messages.Abstraction;
using TestingGiant.Data.Models;

namespace TestingGiant.App.Messages.Authentication
{
    public class SuccessfullyAuthenticatedMessage : BaseMessage
    {
        private User user;

        public SuccessfullyAuthenticatedMessage(User user)
        {
            this.User = user;
        }

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                this.user = value;
            }
        }        
    }
}
