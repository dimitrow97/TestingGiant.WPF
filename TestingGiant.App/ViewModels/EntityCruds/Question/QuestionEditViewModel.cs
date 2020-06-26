using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Question;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Question
{
    public class QuestionEditViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private string title;
        private string description;
        private QuestionType selectedQuestionType;
        private decimal points;
        private Difficulty selectedDifficulty;
        private CategoryModel selectedCategory;
        private SubjectModel selectedSubject;
        private QuestionModel question;

        private string answer;
        private bool isItCorrect;
        private string answerMessage;
        private QuestionAnswerModel selectedQuestionAnswer;

        private bool enableAddButton;

        private bool isTitleOk;
        private bool isDescriptionOk;
        private bool isPointsOk;

        public IReadOnlyList<QuestionType> QuestionTypes { get; }
        public IReadOnlyList<Difficulty> Difficulties { get; }
        public IReadOnlyList<CategoryModel> Categories { get; }
        public IReadOnlyList<SubjectModel> Subjects { get; }

        private BindableCollection<QuestionAnswerModel> questionAnswers;

        private IDeletableEntityRepository<Data.Models.Question> questionRepository;
        private IDeletableEntityRepository<Data.Models.Category> categoryRepository;
        private IDeletableEntityRepository<Data.Models.Subject> subjectRepository;
        private IDeletableEntityRepository<Data.Models.QuestionAnswer> questionAnswerRepository;

        public QuestionEditViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<Data.Models.Question> questionRepository,
            IDeletableEntityRepository<Data.Models.Category> categoryRepository,
            IDeletableEntityRepository<Data.Models.Subject> subjectRepository,
            IDeletableEntityRepository<Data.Models.QuestionAnswer> questionAnswerRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.questionRepository = questionRepository;
            this.categoryRepository = categoryRepository;
            this.subjectRepository = subjectRepository;
            this.questionAnswerRepository = questionAnswerRepository;
            this.QuestionTypes = Enum.GetValues(typeof(QuestionType)).Cast<QuestionType>().ToList();
            this.Difficulties = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            this.Categories = this.categoryRepository.All().Select(x => new CategoryModel { Id = x.Id, Name = x.CategoryName }).ToList();
            this.Subjects = this.subjectRepository.All().Select(x => new SubjectModel { Id = x.Id, Title = x.Title }).ToList();

            this.QuestionAnswers = new BindableCollection<QuestionAnswerModel>();
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
                this.Title = value.Title;
                this.Description = value.Description;
                this.Points = value.Points;
                this.SelectedQuestionType = (QuestionType)Enum.Parse(typeof(QuestionType), value.QuestionType);
                this.SelectedDifficulty = (Difficulty)Enum.Parse(typeof(Difficulty), value.Difficulty);

                this.QuestionAnswers = new BindableCollection<QuestionAnswerModel>(this.questionAnswerRepository.All().Where(x => x.QuestionId == value.Id).Select(x => new QuestionAnswerModel { Answer = x.Answer, Id = x.Id, IsItCorrect = x.IsItCorrect }).ToList());
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public QuestionType SelectedQuestionType
        {
            get => selectedQuestionType;
            set => Set(ref selectedQuestionType, value);
        }

        public decimal Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
                NotifyOfPropertyChange(() => Points);
            }
        }

        public Difficulty SelectedDifficulty
        {
            get => selectedDifficulty;
            set => Set(ref selectedDifficulty, value);
        }

        public CategoryModel SelectedCategory
        {
            get => selectedCategory;
            set => Set(ref selectedCategory, value);
        }

        public SubjectModel SelectedSubject
        {
            get => selectedSubject;
            set => Set(ref selectedSubject, value);
        }

        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                answer = value;
                NotifyOfPropertyChange(() => Answer);
            }
        }

        public string AnswerMessage
        {
            get
            {
                return answerMessage;
            }
            set
            {
                answerMessage = value;
                NotifyOfPropertyChange(() => AnswerMessage);
            }
        }

        public bool IsItCorrect
        {
            get
            {
                return isItCorrect;
            }
            set
            {
                isItCorrect = value;
                NotifyOfPropertyChange(() => IsItCorrect);
            }
        }

        public QuestionAnswerModel SelectedQuestionAnswer
        {
            get
            {
                return selectedQuestionAnswer;
            }
            set
            {
                selectedQuestionAnswer = value;
                NotifyOfPropertyChange(() => SelectedQuestionAnswer);
            }
        }

        public BindableCollection<QuestionAnswerModel> QuestionAnswers
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

        public bool EnableAddButton
        {
            get
            {
                return enableAddButton;
            }
            set
            {
                enableAddButton = value;
                NotifyOfPropertyChange(() => EnableAddButton);
            }
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Title")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Title) || Title?.Length <= 3)
                    {
                        isTitleOk = false;

                        return "Title is Required";
                    }
                    else
                    {
                        isTitleOk = true;
                    }
                }

                if (columnName == "Description")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Description) || Description?.Length <= 3)
                    {
                        isDescriptionOk = false;

                        return "Description is Required";
                    }
                    else
                    {
                        isDescriptionOk = true;
                    }
                }

                if (columnName == "Points")
                {
                    // Validate property and return a string if there is an error
                    if (this.Points < 0)
                    {
                        isPointsOk = false;

                        return "Points must be higher than 0";
                    }
                    else
                    {
                        isPointsOk = true;
                    }
                }

                if (columnName == "Answer")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Answer) || Description?.Length < 1)
                    {
                        return "Answer is Required";
                    }
                }

                // If there's no error, null gets returned
                if (isTitleOk && isDescriptionOk && isPointsOk && this.QuestionAnswers.Any())
                    EnableAddButton = true;

                return null;
            }
        }

        public void AttemptEdit()
        {
            var question = new TestingGiant.Data.Models.Question
            {
                Title = this.Title,
                Description = this.Description,
                QuestionType = this.SelectedQuestionType,
                Difficulty = this.SelectedDifficulty,
                Points = this.Points
            };

            var oldQuestionAnswers = this.questionAnswerRepository.All().Where(x => x.QuestionId == this.Question.Id).ToList();

            foreach (var oldAnswer in oldQuestionAnswers)
            {
                this.questionAnswerRepository.ActualDelete(oldAnswer);
            }

            var questionAnswers = this.QuestionAnswers.Select(x => new QuestionAnswer { Answer = x.Answer, IsItCorrect = x.IsItCorrect, Question = question, CreatedOn = DateTime.Now, CreatorId = shellContext.User.Id }).ToList();

            question.Answers = questionAnswers;

            if (this.SelectedCategory != null)
                question.Categories.Add(this.categoryRepository.GetById(this.SelectedCategory.Id));

            if (this.SelectedSubject != null)
                question.Subjects.Add(this.subjectRepository.GetById(this.SelectedSubject.Id));

            if (!questionRepository.All().Any(x => x.Title == this.Title && x.QuestionType == this.SelectedQuestionType && x.Id != this.Question.Id))
            {
                this.questionRepository.Add(question, shellContext.User?.Id);
                this.questionRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedQuestionMessage());
            }
            else
            {
                Message = "Question already exists";
            }
        }

        public void AddQuestionAnswer()
        {
            if (string.IsNullOrEmpty(Answer) || Answer?.Length < 1)
            {
                this.AnswerMessage = "Answer is Required";
            }
            else
            {
                if (QuestionAnswers.Any(x => x.Answer == this.Answer))
                {
                    this.AnswerMessage = "Answer already exists";
                }
                else if (this.SelectedQuestionType == QuestionType.SingleChoice && this.IsItCorrect)
                {
                    if (QuestionAnswers.Any(x => x.IsItCorrect == true))
                    {
                        this.AnswerMessage = $"Only one correct answer is allowed for Question Type: {this.SelectedQuestionType}";
                    }
                    else
                    {
                        this.QuestionAnswers.Add(new QuestionAnswerModel { Answer = this.Answer, IsItCorrect = this.IsItCorrect });
                        this.Answer = string.Empty;
                    }
                }
                else
                {
                    this.QuestionAnswers.Add(new QuestionAnswerModel { Answer = this.Answer, IsItCorrect = this.IsItCorrect });
                    this.Answer = string.Empty;
                }
            }
        }

        public void DeleteQuestionAnswer()
        {
            if (SelectedQuestionAnswer != null)
            {
                this.QuestionAnswers.Remove(this.SelectedQuestionAnswer);
            }
            else
            {
                this.AnswerMessage = "Please select an Answer first!";
            }
        }
    }
}