using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.Main.ExamPlay
{
    public class ExamPlayResultViewModel : BaseScreenViewModel
    {
        private int answeredQuestions;
        private decimal examResult;

        private ExamModel exam;
        private Dictionary<QuestionModel, QuestionAnswerModel> userAnswers;
        private string examName;
        private decimal maximumScore;

        public ExamPlayResultViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
            : base(eventAggregator, shellContext, applicationRouter)
        {
        }

        public int AnsweredQuestions
        {
            get
            {
                return answeredQuestions;
            }
            set
            {
                this.answeredQuestions = value;
                NotifyOfPropertyChange(() => AnsweredQuestions);
            }
        }

        public decimal ExamResult
        {
            get
            {
                return examResult;
            }
            set
            {
                this.examResult = value;
                NotifyOfPropertyChange(() => ExamResult);
            }
        }

        public decimal MaximumScore
        {
            get
            {
                return maximumScore;
            }
            set
            {
                this.maximumScore = value;
                NotifyOfPropertyChange(() => MaximumScore);
            }
        }

        public string ExamName
        {
            get
            {
                return examName;
            }
            set
            {
                this.examName = value;
                NotifyOfPropertyChange(() => ExamName);
            }
        }

        public ExamModel Exam
        {
            get
            {
                return exam;
            }
            set
            {
                this.exam = value;
                NotifyOfPropertyChange(() => Exam);

                this.ExamName = value.Name;
            }
        }

        public Dictionary<QuestionModel, QuestionAnswerModel> UserAnswers
        {
            get
            {
                return userAnswers;
            }
            set
            {
                this.userAnswers = value;
                NotifyOfPropertyChange(() => UserAnswers);

                this.MaximumScore = 0;
                this.ExamResult = 0;

                foreach (var answer in value)
                {
                    if (answer.Value.IsItCorrect)
                        this.ExamResult += answer.Key.Points;

                    this.MaximumScore += answer.Key.Points;
                }
            }
        }
    }
}
