using TestingGiant.App.Messages.Abstraction;

namespace TestingGiant.App.Messages.Authentication
{
    public class SuccessfullyAuthenticatedMessage : BaseMessage
    {
        private TestingGiant.Data.Models.User user;

        public SuccessfullyAuthenticatedMessage(TestingGiant.Data.Models.User user)
        {
            this.User = user;
        }

        public TestingGiant.Data.Models.User User
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
