using Caliburn.Micro;
using TestingGiant.App.Contexts;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminDashboardViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        private ShellContext shellContext;

        public AdminDashboardViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
