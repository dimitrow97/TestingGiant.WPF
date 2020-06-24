using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Authentication;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.Authentication
{
    public class LoginConductorViewModel : BaseConductorViewModel, IHandle<UserToRegistrationMessage>, IHandle<UserToLoginMessage>
    {
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;

        public LoginConductorViewModel(
            IEventAggregator eventAggregator,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
            : base(eventAggregator, shellContext, applicationRouter)
        {            
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;

            this.RegisterItems(this.loginViewModel, this.registerViewModel);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            this.applicationRouter.ActivateItem(this.loginViewModel, this);
        }        

        public void Handle(UserToRegistrationMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.registerViewModel, this);
        }

        public void Handle(UserToLoginMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.loginViewModel, this);
        }
    }
}
