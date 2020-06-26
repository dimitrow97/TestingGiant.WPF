using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Exam;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Exam
{
    public class ExamsAllViewModel : BaseScreenViewModel
    {
        private ExamModel selectedExam;
        private BindableCollection<ExamModel> exams;

        private readonly IDeletableEntityRepository<Data.Models.Exam> examsRepository;

        public ExamsAllViewModel(
           IEventAggregator eventAggregator,
           ShellContext shellContext,
           ApplicationRouter applicationRouter,
           IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository)
           : base(eventAggregator, shellContext, applicationRouter)
        {
            this.examsRepository = examsRepository;

            this.GetExams();
        }

        public BindableCollection<ExamModel> Exams
        {
            get
            {
                return exams;
            }
            set
            {
                exams = value;
                NotifyOfPropertyChange(() => Exams);
            }
        }

        public ExamModel SelectedExam
        {
            get
            {
                return selectedExam;
            }
            set
            {
                selectedExam = value;
                NotifyOfPropertyChange(() => SelectedExam);
            }
        }

        public void GetExams()
        {
            this.Exams = new BindableCollection<ExamModel>(this.examsRepository.All().Select(x => new ExamModel { Id = x.Id, Name = x.Name, ExamKey = x.ExamKey, ExamPassword = x.ExamPassword, ExamType = x.ExamType.ToString(), MaximumScore = x.MaximumScore, TimeToFinishInMinutes = x.TimeToFinishInMinutes }).ToList());
        }

        public void AddExam()
        {
            this.eventAggregator.PublishOnUIThread(new AddExamDisplayMessage());
        }

        public void EditExam()
        {
            if (this.SelectedExam != null)
            {
                this.eventAggregator.PublishOnUIThread(new EditExamDisplayMessage { Exam = this.SelectedExam });
            }
            else
            {
                this.Message = "Please select an exam first!";
            }
        }

        public void DeleteExam()
        {
            if (this.SelectedExam != null)
            {
                var exam = this.examsRepository.GetById(this.SelectedExam.Id);

                if (exam != null)
                {
                    this.examsRepository.Delete(exam);
                    this.examsRepository.SaveChanges();

                    this.GetExams();

                    this.Message = string.Empty;
                }
            }
            else
            {
                this.Message = "Please select an exam first!";
            }
        }

        public void AddRemoveGroups()
        {
            if (this.SelectedExam != null)
            {
                this.eventAggregator.PublishOnUIThread(new AddRemoveExamGroupMessage { Exam = this.SelectedExam });
            }
            else
            {
                this.Message = "Please select an exam first!";
            }
        }

        public void AddRemoveQuestions()
        {
            if (this.SelectedExam != null)
            {
                this.eventAggregator.PublishOnUIThread(new AddRemoveExamQuestionMessage { Exam = this.SelectedExam });
            }
            else
            {
                this.Message = "Please select an exam first!";
            }
        }
    }
}
