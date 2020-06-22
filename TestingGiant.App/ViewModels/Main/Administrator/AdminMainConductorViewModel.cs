using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.ViewModels.EntityCruds.Category;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminMainConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<GoToCategoriesMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly AdminDashboardViewModel adminDashboardViewModel;

        private readonly CategoryConductorViewModel categoryConductorViewModel;

        private ShellContext shellContext;
        private ApplicationRouter applicationRouter;

        public AdminMainConductorViewModel(
            IEventAggregator eventAggregator,
            AdminDashboardViewModel adminDashboardViewModel,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            CategoryConductorViewModel categoryConductorViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.adminDashboardViewModel = adminDashboardViewModel;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;

            this.categoryConductorViewModel = categoryConductorViewModel;

            Items.AddRange(new Screen[] { this.adminDashboardViewModel, this.categoryConductorViewModel });
        }
        
        public void Handle(GoToCategoriesMessage message)
        {
            this.applicationRouter.ActivateItem(this.categoryConductorViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);

            this.applicationRouter.ActivateItem(this.adminDashboardViewModel, this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
