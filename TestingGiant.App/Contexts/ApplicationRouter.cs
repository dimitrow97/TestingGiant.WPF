using Caliburn.Micro;

namespace TestingGiant.App.Contexts
{
    public class ApplicationRouter
    {
        public Conductor<Screen>.Collection.OneActive PreviousConductor { get; set; }

        public Conductor<Screen>.Collection.OneActive CurrentConductor { get; set; }

        public Screen CurrentScreen { get; set; }

        public Screen PreviousScreen { get; set; }

        public void ActivateItem(Screen currentScreen, Conductor<Screen>.Collection.OneActive currentConductor = null)
        {
            this.PreviousScreen = this.CurrentScreen;
            this.CurrentScreen = currentScreen;

            if(currentConductor != null)
            {
                this.PreviousConductor = this.CurrentConductor;
                this.CurrentConductor = currentConductor;
            }

            this.CurrentConductor.ActivateItem(this.CurrentScreen);
        }

        public void RouteBack()
        {
            if(this.PreviousConductor != null && this.PreviousScreen != null)
            {
                this.PreviousConductor.ActivateItem(this.PreviousScreen);
            }
        }
    }
}
