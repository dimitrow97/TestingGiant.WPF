using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.ViewModels.Authentication;

namespace TestingGiant.App.ViewModels
{
    public class ShellConductorViewModel : Conductor<object>.Collection.OneActive, IHandle<SuccessfullyAuthenticatedMessage>
    {
        private ShellContext shellContext;
        private readonly LoginConductorViewModel loginViewModel;

        public ShellConductorViewModel(
            ShellContext shellContext,
            LoginConductorViewModel loginViewModel)
        {
            this.shellContext = shellContext;
            this.loginViewModel = loginViewModel;

            Items.Add(new Screen[] { loginViewModel });
        }

        public void Handle(SuccessfullyAuthenticatedMessage message)
        {
            this.shellContext.User = message.User;
            //open main menu
            //open for admin
            //open for user
        }

        protected override void OnActivate()
        {
            ActivateItem(loginViewModel);
        }
    }
}
