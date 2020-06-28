using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.Subject
{
    public class SubjectConductorViewModel : BaseConductorViewModel, IHandle<AddSubjectDisplayMessage>, IHandle<SuccessfullyAddedOrEditedSubjectMessage>, IHandle<EditSubjectDisplayMessage>
    {
        private readonly SubjectsAllViewModel subjectsAllViewModel;
        private readonly SubjectAddViewModel subjectAddViewModel;
        private readonly SubjectEditViewModel subjectEditViewModel;

        public SubjectConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            SubjectsAllViewModel subjectsAllViewModel,
            SubjectAddViewModel subjectAddViewModel,
            SubjectEditViewModel subjectEditViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {            
            this.subjectsAllViewModel = subjectsAllViewModel;
            this.subjectAddViewModel = subjectAddViewModel;
            this.subjectEditViewModel = subjectEditViewModel;

            this.RegisterItems(this.subjectsAllViewModel, this.subjectAddViewModel, this.subjectEditViewModel);
        }

        public void Handle(AddSubjectDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.subjectAddViewModel, this);
        }

        public void Handle(SuccessfullyAddedOrEditedSubjectMessage message)
        {
            this.subjectsAllViewModel.GetSubjects();
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.subjectsAllViewModel, this);
        }

        public void Handle(EditSubjectDisplayMessage message)
        {
            this.subjectEditViewModel.Subject = message.SubjectModel;
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.subjectEditViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.subjectsAllViewModel.GetSubjects();
            this.applicationRouter.ActivateItem(this.subjectsAllViewModel, this);
        }
    }
}
