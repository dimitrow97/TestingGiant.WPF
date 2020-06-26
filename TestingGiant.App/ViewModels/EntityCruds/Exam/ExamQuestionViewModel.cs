using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Exam
{
    public class ExamQuestionViewModel : BaseScreenViewModel
    {
        private ExamModel exam;
        private QuestionModel selectedMemberQuestion;
        private QuestionModel selectedNotMemberQuestion;

        private BindableCollection<QuestionModel> notMemberQuestions;
        private BindableCollection<QuestionModel> memberQuestions;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository;
        private IDeletableEntityRepository<TestingGiant.Data.Models.Question> questionsRepository;

        public ExamQuestionViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository,
            IDeletableEntityRepository<TestingGiant.Data.Models.Question> questionsRepository)
            : base(eventAggregato, shellContext, applicationRouter)
        {
            this.examsRepository = examsRepository;
            this.questionsRepository = questionsRepository;
        }

        public BindableCollection<QuestionModel> MemberQuestions
        {
            get
            {
                return memberQuestions;
            }
            set
            {
                memberQuestions = value;
                NotifyOfPropertyChange(() => MemberQuestions);
            }
        }

        public BindableCollection<QuestionModel> NotMemberQuestions
        {
            get
            {
                return notMemberQuestions;
            }
            set
            {
                notMemberQuestions = value;
                NotifyOfPropertyChange(() => NotMemberQuestions);
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
                exam = value;
                NotifyOfPropertyChange(() => Exam);

                this.GetQuestions();
            }
        }

        public QuestionModel SelectedMemberQuestion
        {
            get
            {
                return selectedMemberQuestion;
            }
            set
            {
                selectedMemberQuestion = value;
                NotifyOfPropertyChange(() => SelectedMemberQuestion);
            }
        }

        public QuestionModel SelectedNotMemberQuestion
        {
            get
            {
                return selectedNotMemberQuestion;
            }
            set
            {
                selectedNotMemberQuestion = value;
                NotifyOfPropertyChange(() => SelectedNotMemberQuestion);
            }
        }

        public void GetQuestions()
        {
            this.MemberQuestions = new BindableCollection<QuestionModel>(this.examsRepository.GetById(this.Exam.Id).Questions.Select(x => new QuestionModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Difficulty = x.Difficulty.ToString(),
                Points = x.Points,
                QuestionType = x.QuestionType.ToString()
            }).ToList());
            this.NotMemberQuestions = new BindableCollection<QuestionModel>(this.questionsRepository.All().Where(x => !x.Exams.Any(y => y.Id == this.Exam.Id)).Select(x => new QuestionModel
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
            if (this.SelectedNotMemberQuestion != null)
            {
                var exam = this.examsRepository.GetById(this.Exam.Id);

                exam.Questions.Add(this.questionsRepository.GetById(this.SelectedNotMemberQuestion.Id));

                this.examsRepository.Update(exam);
                this.examsRepository.SaveChanges();
                this.GetQuestions();
            }
            else
            {
                this.Message = "Please select a question from the \"Not a member of Groups\" table!";
            }
        }

        public void RemoveQuestion()
        {
            if (this.SelectedMemberQuestion != null)
            {
                var exam = this.examsRepository.GetById(this.Exam.Id);

                exam.Questions.Remove(this.questionsRepository.GetById(this.SelectedMemberQuestion.Id));

                this.examsRepository.Update(exam);
                this.examsRepository.SaveChanges();
                this.GetQuestions();
            }
            else
            {
                this.Message = "Please select a question from the \"Member of Groups\" table!";
            }
        }
    }
}
