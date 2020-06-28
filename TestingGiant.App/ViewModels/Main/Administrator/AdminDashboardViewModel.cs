using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.ExamPlay;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.Main.Administrator
{
    public class AdminDashboardViewModel : BaseScreenViewModel
    {
        private ExamModel selectedExam;
        private BindableCollection<ExamModel> exams;

        private readonly IDeletableEntityRepository<Data.Models.Exam> examsRepository;

        public AdminDashboardViewModel(
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

        public void PlayExam()
        {
            if (this.SelectedExam != null)
            {
                this.eventAggregator.PublishOnUIThread(new PlayExamMessage { Exam = this.SelectedExam });
            }
            else
            {
                this.Message = "Select an exam first!";
            }
        }
    }
}
