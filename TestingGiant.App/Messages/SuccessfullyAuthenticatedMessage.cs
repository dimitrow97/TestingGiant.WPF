using TestingGiant.Data.Models;

namespace TestingGiant.App.Messages
{
    public class SuccessfullyAuthenticatedMessage
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
