using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.ViewModels.Authentication;
using TestingGiant.App.ViewModels.Main.Administrator;
using TestingGiant.Data.Enums;

namespace TestingGiant.App.ViewModels
{
    public class ShellConductorViewModel : Conductor<object>.Collection.OneActive, IHandle<SuccessfullyAuthenticatedMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private ShellContext shellContext;
        private readonly LoginConductorViewModel loginConductorViewModel;
        private readonly AdminMainConductorViewModel adminMainConductorViewModel;

        public ShellConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            LoginConductorViewModel loginConductorViewModel,
            AdminMainConductorViewModel adminMainConductorViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
            this.loginConductorViewModel = loginConductorViewModel;
            this.adminMainConductorViewModel = adminMainConductorViewModel;

            Items.Add(new Screen[] { this.loginConductorViewModel, this.adminMainConductorViewModel });
        }

        public void Handle(SuccessfullyAuthenticatedMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.shellContext.SetCurrentUser(message.User);
            //open main menu
            if(this.shellContext.User?.Role == UserRole.Administrator)
            {
                ActivateItem(this.adminMainConductorViewModel);
            }
            else
            {

            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
            ActivateItem(loginConductorViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
