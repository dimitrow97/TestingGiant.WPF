using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.ExamPlay;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.Main.ExamPlay
{
    public class ExamPlayConductorViewModel : BaseConductorViewModel, IHandle<ExamPlaySuccessfulAuthMessage>, IHandle<ExamPlayQuestionAnswerMessage>
    {
        private ExamModel exam;
        private List<QuestionModel> questions;
        private int currentQuestionIndex;
        private Dictionary<QuestionModel, QuestionAnswerModel> userAnswers;

        private ExamPlayLoginViewModel examPlayLoginViewModel;
        private ExamPlayQuestionViewModel examPlayQuestionViewModel;
        private ExamPlayResultViewModel examPlayResultViewModel;

        private readonly IDeletableEntityRepository<Exam> examRepository;

        public ExamPlayConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<Exam> examRepository,
            ExamPlayLoginViewModel examPlayLoginViewModel,
            ExamPlayQuestionViewModel examPlayQuestionViewModel,
            ExamPlayResultViewModel examPlayResultViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.examRepository = examRepository;

            this.examPlayLoginViewModel = examPlayLoginViewModel;
            this.examPlayQuestionViewModel = examPlayQuestionViewModel;
            this.examPlayResultViewModel = examPlayResultViewModel;

            this.RegisterItems(this.examPlayLoginViewModel, this.examPlayQuestionViewModel, this.examPlayResultViewModel);
        }

        public ExamModel Exam
        {
            get
            {
                return exam;
            }
            set
            {
                exam = value;
                NotifyOfPropertyChange(() => Exam);

                this.examPlayLoginViewModel.ExamKey = value.ExamKey;
                this.examPlayLoginViewModel.ExamPassword = value.ExamPassword;

                currentQuestionIndex = 0;
                userAnswers = new Dictionary<QuestionModel, QuestionAnswerModel>();

                this.Questions = this.examRepository.GetById(value.Id).Questions.Select(x => new QuestionModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Difficulty = x.Difficulty.ToString(),
                    Points = x.Points,
                    QuestionType = x.QuestionType.ToString()
                }).ToList();
            }
        }

        public List<QuestionModel> Questions
        {
            get
            {
                return questions;
            }
            set
            {
                questions = value;
                NotifyOfPropertyChange(() => Questions);
            }
        }

        public void Handle(ExamPlaySuccessfulAuthMessage message)
        {
            this.examPlayQuestionViewModel.Question = this.Questions[currentQuestionIndex++];
            this.applicationRouter.ActivateItem(this.examPlayQuestionViewModel);
        }

        public void Handle(ExamPlayQuestionAnswerMessage message)
        {
            userAnswers.Add(message.Question, message.QuestionAnswer);

            if (currentQuestionIndex < this.Questions.Count)
            {
                this.examPlayQuestionViewModel.Question = this.Questions[currentQuestionIndex++];
                this.applicationRouter.ActivateItem(this.examPlayQuestionViewModel);
            }
            else
            {
                this.examPlayResultViewModel.UserAnswers = this.userAnswers;
                this.examPlayResultViewModel.Exam = this.Exam;
                this.applicationRouter.ActivateItem(this.examPlayResultViewModel, this);
            }            
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.examPlayLoginViewModel.ExamKey = this.Exam.ExamKey;
            this.examPlayLoginViewModel.ExamPassword = this.Exam.ExamPassword;
            this.applicationRouter.ActivateItem(this.examPlayLoginViewModel, this);
        }
    }
}
