using Caliburn.Micro;
using TestingGiant.App.Contexts;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminMainConductorViewModel : Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator eventAggregator;
        private readonly AdminDashboardViewModel adminDashboardViewModel;
        private ShellContext shellContext;

        public AdminMainConductorViewModel(
            IEventAggregator eventAggregator,
            AdminDashboardViewModel adminDashboardViewModel,
            ShellContext shellContext)
        {
            this.eventAggregator = eventAggregator;
            this.adminDashboardViewModel = adminDashboardViewModel;
            this.shellContext = shellContext;

            Items.AddRange(new Screen[] { this.adminDashboardViewModel });
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
            ActivateItem(this.adminDashboardViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
