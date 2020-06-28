using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Question;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.Question
{
    public class QuestionConductorViewModel : BaseConductorViewModel, IHandle<AddQuestionDisplayMessage>, IHandle<EditQuestionDisplayMessage>, IHandle<SuccessfullyAddedOrEditedQuestionMessage>
    {
        private readonly QuestionsAllViewModel questionsAllViewModel;
        private readonly QuestionAddViewModel questionAddViewModel;
        private readonly QuestionEditViewModel questionEditViewModel;

        public QuestionConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            QuestionsAllViewModel questionsAllViewModel,
            QuestionAddViewModel questionAddViewModel,
            QuestionEditViewModel questionEditViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.questionsAllViewModel = questionsAllViewModel;
            this.questionAddViewModel = questionAddViewModel;
            this.questionEditViewModel = questionEditViewModel;

            this.RegisterItems(this.questionsAllViewModel, this.questionAddViewModel, this.questionEditViewModel);
        }

        public void Handle(AddQuestionDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.questionAddViewModel.LoadItems();
            this.applicationRouter.ActivateItem(this.questionAddViewModel, this);
        }

        public void Handle(EditQuestionDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.questionEditViewModel.Question = message.QuestionModel;
            this.questionEditViewModel.LoadItems();
            this.applicationRouter.ActivateItem(this.questionEditViewModel, this);
        }

        public void Handle(SuccessfullyAddedOrEditedQuestionMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.questionsAllViewModel.GetQuestions();
            this.applicationRouter.ActivateItem(this.questionsAllViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.questionsAllViewModel.GetQuestions();
            this.applicationRouter.ActivateItem(this.questionsAllViewModel, this);
        }
    }
}
