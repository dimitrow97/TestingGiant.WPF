using TestingGiant.Data.Models;

namespace TestingGiant.App.Contexts
{
    public class ShellContext
    {
        private User user;

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
