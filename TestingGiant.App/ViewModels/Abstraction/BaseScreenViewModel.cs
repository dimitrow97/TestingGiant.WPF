using Caliburn.Micro;
using TestingGiant.App.Contexts;

namespace TestingGiant.App.ViewModels.Abstraction
{
    public abstract class BaseScreenViewModel : Screen
    {
        private string message;

        protected readonly IEventAggregator eventAggregator;

        protected ShellContext shellContext;
        protected ApplicationRouter applicationRouter;

        protected BaseScreenViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
            }
        }

        public virtual void GoBack()
        {
            this.applicationRouter.RouteBack();
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
