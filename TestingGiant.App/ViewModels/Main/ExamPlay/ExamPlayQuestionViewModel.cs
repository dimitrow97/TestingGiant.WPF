using Caliburn.Micro;
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
    public class ExamPlayQuestionViewModel : BaseScreenViewModel
    {
        private QuestionModel question;

        private List<QuestionAnswerModel> questionAnswers;
        private string questionTitle;
        private string questionDescription;
        private string a;
        private string b;
        private string c;
        private string d;
        private readonly IDeletableEntityRepository<Question> questionRepository;

        public ExamPlayQuestionViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<Question> questionRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.questionRepository = questionRepository;
        }

        public QuestionModel Question
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
                NotifyOfPropertyChange(() => Question);

                questionAnswers = this.questionRepository.GetById(value.Id)
                    .Answers.Select(x => new QuestionAnswerModel { Id = x.Id, Answer = x.Answer, IsItCorrect = x.IsItCorrect })
                    .ToList();

                QuestionTitle = this.Question.Title;
                QuestionDescription = this.Question.Description;
                A = this.QuestionAnswers[0].Answer;
                B = this.QuestionAnswers[1].Answer;
                C = this.QuestionAnswers[2].Answer;
                D = this.QuestionAnswers[3].Answer;
            }
        }

        public List<QuestionAnswerModel> QuestionAnswers
        {
            get
            {
                return questionAnswers;
            }
            set
            {
                questionAnswers = value;
                NotifyOfPropertyChange(() => QuestionAnswers);
            }
        }

        public string QuestionTitle
        {
            get
            {
                return questionTitle;
            }
            set
            {
                questionTitle = value;
                NotifyOfPropertyChange(() => QuestionTitle);
            }
        }

        public string QuestionDescription
        {
            get
            {
                return questionDescription;
            }
            set
            {
                questionDescription = value;
                NotifyOfPropertyChange(() => QuestionDescription);
            }
        }

        public string A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                NotifyOfPropertyChange(() => A);
            }
        }

        public string B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                NotifyOfPropertyChange(() => B);
            }
        }

        public string C
        {
            get
            {
                return c;
            }
            set
            {
                c = value;
                NotifyOfPropertyChange(() => C);
            }
        }

        public string D
        {
            get
            {
                return d;
            }
            set
            {
                d = value;
                NotifyOfPropertyChange(() => D);
            }
        }

        public void AnswerA()
        {
            this.eventAggregator.PublishOnUIThread(new ExamPlayQuestionAnswerMessage { Question = this.Question, QuestionAnswer = this.QuestionAnswers[0] });
        }

        public void AnswerB()
        {
            this.eventAggregator.PublishOnUIThread(new ExamPlayQuestionAnswerMessage { Question = this.Question, QuestionAnswer = this.QuestionAnswers[1] });
        }

        public void AnswerC()
        {
            this.eventAggregator.PublishOnUIThread(new ExamPlayQuestionAnswerMessage { Question = this.Question, QuestionAnswer = this.QuestionAnswers[2] });
        }

        public void AnswerD()
        {
            this.eventAggregator.PublishOnUIThread(new ExamPlayQuestionAnswerMessage { Question = this.Question, QuestionAnswer = this.QuestionAnswers[3] });
        }
    }
}
