using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Exam;
using TestingGiant.App.Messages.ExamPlay;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.Messages.Question;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.Messages.User;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.App.ViewModels.EntityCruds.Category;
using TestingGiant.App.ViewModels.EntityCruds.Exam;
using TestingGiant.App.ViewModels.EntityCruds.Group;
using TestingGiant.App.ViewModels.EntityCruds.Question;
using TestingGiant.App.ViewModels.EntityCruds.Subject;
using TestingGiant.App.ViewModels.EntityCruds.User;
using TestingGiant.App.ViewModels.Main.ExamPlay;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminMainConductorViewModel : BaseConductorViewModel, IHandle<PlayExamMessage>, IHandle<GoToDashboardMessage>, IHandle<GoToCategoriesMessage>, IHandle<GoToGroupsMessage>, IHandle<GoToQuestionsMessage>, IHandle<GoToSubjectsMessage>, IHandle<GoToUsersMessage>, IHandle<GoToExamMessage>
    {
        private readonly AdminDashboardViewModel adminDashboardViewModel;

        private readonly CategoryConductorViewModel categoryConductorViewModel;
        private readonly GroupConductorViewModel groupConductorViewModel;
        private readonly QuestionConductorViewModel questionConductorViewModel;
        private readonly SubjectConductorViewModel subjectConductorViewModel;
        private readonly UserConductorViewModel userConductorViewModel;
        private readonly ExamConductorViewModel examConductorViewModel;
        private readonly ExamPlayConductorViewModel examPlayConductorViewModel;

        public AdminMainConductorViewModel(
            IEventAggregator eventAggregator,
            AdminDashboardViewModel adminDashboardViewModel,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            CategoryConductorViewModel categoryConductorViewModel,
            GroupConductorViewModel groupConductorViewModel,
            QuestionConductorViewModel questionConductorViewModel,
            SubjectConductorViewModel subjectConductorViewModel,
            UserConductorViewModel userConductorViewModel,
            ExamConductorViewModel examConductorViewModel,
            ExamPlayConductorViewModel examPlayConductorViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.adminDashboardViewModel = adminDashboardViewModel;

            this.categoryConductorViewModel = categoryConductorViewModel;
            this.groupConductorViewModel = groupConductorViewModel;
            this.questionConductorViewModel = questionConductorViewModel;
            this.subjectConductorViewModel = subjectConductorViewModel;
            this.userConductorViewModel = userConductorViewModel;
            this.examConductorViewModel = examConductorViewModel;
            this.examPlayConductorViewModel = examPlayConductorViewModel;

            this.RegisterItems(
                this.adminDashboardViewModel, 
                this.categoryConductorViewModel,
                this.groupConductorViewModel, 
                this.questionConductorViewModel, 
                this.subjectConductorViewModel,
                this.userConductorViewModel,
                this.examConductorViewModel,
                this.examPlayConductorViewModel);
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

        public void Handle(GoToQuestionsMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.questionConductorViewModel, this);
        }

        public void Handle(GoToSubjectsMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.subjectConductorViewModel, this);
        }

        public void Handle(GoToUsersMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.userConductorViewModel, this);
        }

        public void Handle(GoToExamMessage message)
        {

            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.examConductorViewModel, this);
        }

        public void Handle(PlayExamMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.examPlayConductorViewModel.Exam = message.Exam;
            this.applicationRouter.ActivateItem(this.examPlayConductorViewModel, this);
        }

        public void Handle(GoToDashboardMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            adminDashboardViewModel.GetExams();
            this.applicationRouter.ActivateItem(this.adminDashboardViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            adminDashboardViewModel.GetExams();
            this.applicationRouter.ActivateItem(this.adminDashboardViewModel, this);
        }
    }
}
