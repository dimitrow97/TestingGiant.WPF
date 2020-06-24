using Caliburn.Micro;
using TestingGiant.App.Contexts;

namespace TestingGiant.App.ViewModels.Abstraction
{
    public abstract class BaseConductorViewModel : Conductor<Screen>.Collection.OneActive
    {
        protected readonly IEventAggregator eventAggregator;
        
        protected ShellContext shellContext;
        protected ApplicationRouter applicationRouter;

        protected BaseConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;
        }

        protected void RegisterItems(params Screen[] screens)
        {
            Items.AddRange(screens);
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
