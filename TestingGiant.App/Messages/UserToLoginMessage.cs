namespace TestingGiant.App.Messages
{
    public class UserToLoginMessage : BaseMessage
    {
        string message;

        public UserToLoginMessage()
        {
        }

        public UserToLoginMessage(string message)
        {
            this.Message = message;
        }

        string Message
        {
            get
            {
                return message;
            }
            set
            {
                this.message = value;
            }
        }
    }
}
