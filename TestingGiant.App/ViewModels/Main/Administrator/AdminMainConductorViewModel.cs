using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.App.ViewModels.EntityCruds.Category;
using TestingGiant.App.ViewModels.EntityCruds.Group;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminMainConductorViewModel : BaseConductorViewModel, IHandle<GoToCategoriesMessage>, IHandle<GoToGroupsMessage>
    {
        private readonly AdminDashboardViewModel adminDashboardViewModel;

        private readonly CategoryConductorViewModel categoryConductorViewModel;
        private readonly GroupConductorViewModel groupConductorViewModel;

        public AdminMainConductorViewModel(
            IEventAggregator eventAggregator,
            AdminDashboardViewModel adminDashboardViewModel,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            CategoryConductorViewModel categoryConductorViewModel,
            GroupConductorViewModel groupConductorViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.adminDashboardViewModel = adminDashboardViewModel;

            this.categoryConductorViewModel = categoryConductorViewModel;
            this.groupConductorViewModel = groupConductorViewModel;

            this.RegisterItems(this.adminDashboardViewModel, this.categoryConductorViewModel, this.groupConductorViewModel);
        }
        
        public void Handle(GoToCategoriesMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.categoryConductorViewModel, this);
        }

        public void Handle(GoToGroupsMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.groupConductorViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            this.applicationRouter.ActivateItem(this.adminDashboardViewModel, this);
        }
    }
}
