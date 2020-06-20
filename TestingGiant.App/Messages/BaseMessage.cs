using System;

namespace TestingGiant.App.Messages
{
    public abstract class BaseMessage
    {
        public string message;
        
        public string Message
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

        public string MessageType
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
