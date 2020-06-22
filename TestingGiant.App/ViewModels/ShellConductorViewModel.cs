using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.Messages.Authentication;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.ViewModels.Authentication;
using TestingGiant.App.ViewModels.Main.Administrator;
using TestingGiant.Data.Enums;

namespace TestingGiant.App.ViewModels
{
    public class ShellConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<SuccessfullyAuthenticatedMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private ShellContext shellContext;
        private ApplicationRouter applicationRouter;
        private readonly LoginConductorViewModel loginConductorViewModel;
        private readonly AdminMainConductorViewModel adminMainConductorViewModel;

        public ShellConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            LoginConductorViewModel loginConductorViewModel,
            AdminMainConductorViewModel adminMainConductorViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;
            this.loginConductorViewModel = loginConductorViewModel;
            this.adminMainConductorViewModel = adminMainConductorViewModel;

            Items.AddRange(new Screen[] { this.loginConductorViewModel, this.adminMainConductorViewModel });
        }

        public void Handle(SuccessfullyAuthenticatedMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.shellContext.SetCurrentUser(message.User);
            //open main menu
            if (this.shellContext.User?.Role == UserRole.Administrator)
            {
                this.applicationRouter.ActivateItem(this.adminMainConductorViewModel, this);
            }
            else
            {

            }
        }

        public void GoToCategories()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToCategoriesMessage());
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
            this.applicationRouter.ActivateItem(this.loginConductorViewModel, this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
