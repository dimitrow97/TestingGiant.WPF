using TestingGiant.App.Messages.Abstraction;

namespace TestingGiant.App.Messages.Authentication
{
    public class UserToLoginMessage : BaseMessage
    {
        public UserToLoginMessage()
        {
        }

        public UserToLoginMessage(string message, bool successfullRegistration)
        {
            this.Message = message;
            this.SuccessfullRegistration = successfullRegistration;
        }

        public bool SuccessfullRegistration { get; set; }        
    }
}
