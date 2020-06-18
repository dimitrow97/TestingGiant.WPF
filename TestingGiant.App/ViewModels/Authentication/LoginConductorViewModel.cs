using Caliburn.Micro;
using TestingGiant.App.Messages;

namespace TestingGiant.App.ViewModels.Authentication
{
    public class LoginConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<UserToRegistrationMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;

        public LoginConductorViewModel(
            IEventAggregator eventAggregator,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;

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
            ActivateItem(this.registerViewModel);
        }
    }
}
