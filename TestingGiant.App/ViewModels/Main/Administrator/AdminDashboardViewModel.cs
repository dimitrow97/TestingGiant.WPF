using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminDashboardViewModel : BaseScreenViewModel
    {
        public AdminDashboardViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
            : base(eventAggregator, shellContext, applicationRouter)
        {
        }
    }
}
