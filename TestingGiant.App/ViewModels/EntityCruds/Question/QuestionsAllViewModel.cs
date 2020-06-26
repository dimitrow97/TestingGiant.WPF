using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Question;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Question
{
    public class QuestionsAllViewModel : BaseScreenViewModel
    {
        private QuestionModel selectedQuestion;
        private BindableCollection<QuestionModel> questions;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Question> questionRepository;

        public QuestionsAllViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Question> questionRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.questionRepository = questionRepository;

            this.GetQuestions();
        }

        public BindableCollection<QuestionModel> Questions
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

        public QuestionModel SelectedQuestion
        {
            get
            {
                return selectedQuestion;
            }
            set
            {
                selectedQuestion = value;
                NotifyOfPropertyChange(() => SelectedQuestion);
            }
        }


        public void GetQuestions()
        {
            this.Questions = new BindableCollection<QuestionModel>(
                this.questionRepository.All().Select(x => new QuestionModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Difficulty = x.Difficulty.ToString(),
                    Points = x.Points,
                    QuestionType = x.QuestionType.ToString()
                }).ToList());
        }

        public void AddQuestion()
        {
            this.eventAggregator.PublishOnUIThread(new AddQuestionDisplayMessage());
        }

        public void EditQuestion()
        {
            if (this.SelectedQuestion != null)
            {
                this.eventAggregator.PublishOnUIThread(new EditQuestionDisplayMessage { QuestionModel = this.SelectedQuestion });
            }
            else
            {
                this.Message = "Please select a question first!";
            }
        }

        public void DeleteQuestion()
        {
            if (this.SelectedQuestion != null)
            {
                var category = this.questionRepository.GetById(this.SelectedQuestion.Id);

                if (category != null)
                {
                    this.questionRepository.Delete(category);
                    this.questionRepository.SaveChanges();

                    this.GetQuestions();

                    this.Message = string.Empty;
                }
            }
            else
            {
                this.Message = "Please select a question first!";
            }
        }
    }
}
