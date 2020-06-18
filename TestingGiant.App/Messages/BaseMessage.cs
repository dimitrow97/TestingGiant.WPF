using System;

namespace TestingGiant.App.Messages
{
    public abstract class BaseMessage
    {
        public string message;
        public Type messageType;
        
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

        public Type MessageType
        {
            get
            {
                return messageType;
            }
            set
            {
                this.messageType = this.GetType();
            }
        }
    }
}
