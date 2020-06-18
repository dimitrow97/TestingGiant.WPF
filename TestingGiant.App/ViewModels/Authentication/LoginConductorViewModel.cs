using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;

namespace TestingGiant.App.ViewModels.Authentication
{
    public class LoginConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<UserToRegistrationMessage>, IHandle<UserToLoginMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;

        private ShellContext shellContext;

        public LoginConductorViewModel(
            IEventAggregator eventAggregator,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel,
            ShellContext shellContext)
        {
            this.eventAggregator = eventAggregator;
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;
            this.shellContext = shellContext;

            Items.AddRange(new Screen[] { this.loginViewModel, this.registerViewModel });
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
            ActivateItem(this.loginViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }

        public void Handle(UserToRegistrationMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            ActivateItem(this.registerViewModel);
        }

        public void Handle(UserToLoginMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            ActivateItem(this.loginViewModel);
        }
    }
}
