using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Authentication;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Exam;
using TestingGiant.App.Messages.ExamPlay;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.Messages.Question;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.Messages.User;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.App.ViewModels.Authentication;
using TestingGiant.App.ViewModels.Main.Administrator;
using TestingGiant.Data.Enums;

namespace TestingGiant.App.ViewModels
{
    public class ShellConductorViewModel : BaseConductorViewModel, IHandle<SuccessfullyAuthenticatedMessage>
    {
        private string isUserAdmin;

        private readonly LoginConductorViewModel loginConductorViewModel;
        private readonly AdminMainConductorViewModel adminMainConductorViewModel;

        public ShellConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            LoginConductorViewModel loginConductorViewModel,
            AdminMainConductorViewModel adminMainConductorViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.loginConductorViewModel = loginConductorViewModel;
            this.adminMainConductorViewModel = adminMainConductorViewModel;

            this.RegisterItems(this.loginConductorViewModel, this.adminMainConductorViewModel);

            IsUserAdmin = "Hidden";
        }

        public string IsUserAdmin
        {
            get
            {
                return isUserAdmin;
            }
            set
            {
                isUserAdmin = value;
                NotifyOfPropertyChange(() => IsUserAdmin);
            }
        }

        public void Handle(SuccessfullyAuthenticatedMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.shellContext.SetCurrentUser(message.User);

            if (this.shellContext.User?.Role == UserRole.Administrator)
            {
                this.IsUserAdmin = "Visible";
            }
            else
            {
                this.IsUserAdmin = "Hidden";
            }

            this.applicationRouter.ActivateItem(this.adminMainConductorViewModel, this);
        }

        public void GoToDashboard()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToDashboardMessage());
        }

        public void GoToCategories()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToCategoriesMessage());
        }

        public void GoToGroups()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToGroupsMessage());
        }

        public void GoToQuestions()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToQuestionsMessage());
        }

        public void GoToSubjects()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToSubjectsMessage());
        }

        public void GoToUsers()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToUsersMessage());
        }

        public void GoToExams()
        {
            if (this.shellContext.User != null)
                this.eventAggregator.PublishOnUIThread(new GoToExamMessage());
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            this.applicationRouter.ActivateItem(this.loginConductorViewModel, this);
        }
    }
}
