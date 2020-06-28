using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Exam;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.Exam
{
    public class ExamConductorViewModel : BaseConductorViewModel, IHandle<SuccessfullyAddedOrEditedExamMessage>, IHandle<AddExamDisplayMessage>, IHandle<EditExamDisplayMessage>, IHandle<AddRemoveExamGroupMessage>, IHandle<AddRemoveExamQuestionMessage>
    {
        private readonly ExamsAllViewModel examsAllViewModel;
        private readonly ExamAddViewModel examAddViewModel;
        private readonly ExamEditViewModel examEditViewModel;
        private readonly ExamGroupViewModel examGroupViewModel;
        private readonly ExamQuestionViewModel examQuestionViewModel;

        public ExamConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            ExamsAllViewModel examsAllViewModel,
            ExamAddViewModel examAddViewModel,
            ExamEditViewModel examEditViewModel,
            ExamGroupViewModel examGroupViewModel,
            ExamQuestionViewModel examQuestionViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.examsAllViewModel = examsAllViewModel;
            this.examAddViewModel = examAddViewModel;
            this.examEditViewModel = examEditViewModel;
            this.examGroupViewModel = examGroupViewModel;
            this.examQuestionViewModel = examQuestionViewModel;

            this.RegisterItems(this.examsAllViewModel, this.examAddViewModel, this.examEditViewModel, this.examGroupViewModel, this.examQuestionViewModel);
        }

        public void Handle(SuccessfullyAddedOrEditedExamMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.examsAllViewModel.GetExams();
            this.applicationRouter.ActivateItem(this.examsAllViewModel, this);
        }

        public void Handle(AddExamDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            examAddViewModel.LoadItems();
            this.applicationRouter.ActivateItem(this.examAddViewModel, this);
        }

        public void Handle(EditExamDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.examEditViewModel.Exam = message.Exam;
            examEditViewModel.LoadItems();
            this.applicationRouter.ActivateItem(this.examEditViewModel, this);
        }

        public void Handle(AddRemoveExamGroupMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.examGroupViewModel.Exam = message.Exam;
            this.examGroupViewModel.GetGroups();
            this.applicationRouter.ActivateItem(this.examGroupViewModel, this);
        }

        public void Handle(AddRemoveExamQuestionMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.examQuestionViewModel.Exam = message.Exam;
            this.examQuestionViewModel.GetQuestions();
            this.applicationRouter.ActivateItem(this.examQuestionViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.examsAllViewModel.GetExams();
            this.applicationRouter.ActivateItem(this.examsAllViewModel, this);
        }
    }
}
