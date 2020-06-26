using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Subject
{
    public class SubjectsAllViewModel : BaseScreenViewModel
    {
        private SubjectModel selectedSubjecty;
        private BindableCollection<SubjectModel> subjects;
               
        private IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectsRepository;        

        public SubjectsAllViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectsRepository)
            : base(eventAggregato, shellContext, applicationRouter)
        {            
            this.subjectsRepository = subjectsRepository;

            this.GetSubjects();
        }

        public BindableCollection<SubjectModel> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                NotifyOfPropertyChange(() => Subjects);
            }
        }

        public SubjectModel SelectedSubject
        {
            get
            {
                return selectedSubjecty;
            }
            set
            {
                selectedSubjecty = value;
                NotifyOfPropertyChange(() => SelectedSubject);
            }
        }

        public void GetSubjects()
        {
            this.Subjects = new BindableCollection<SubjectModel>(this.subjectsRepository.All().Select(x => new SubjectModel { Id = x.Id, Title = x.Title }).ToList());
        }

        public void AddSubject()
        {
            this.eventAggregator.PublishOnUIThread(new AddSubjectDisplayMessage());
        }

        public void EditSubject()
        {
            if (this.SelectedSubject != null)
            {
                this.eventAggregator.PublishOnUIThread(new EditSubjectDisplayMessage { SubjectModel = this.SelectedSubject });
            }
            else
            {
                this.Message = "Please select a subject first!";
            }
        }

        public void DeleteSubject()
        {
            if (this.SelectedSubject != null)
            {
                var subject = this.subjectsRepository.GetById(this.SelectedSubject.Id);

                if(subject != null)
                {
                    this.subjectsRepository.Delete(subject);
                    this.subjectsRepository.SaveChanges();

                    this.GetSubjects();

                    this.Message = string.Empty;
                }
            }
            else
            {
                this.Message = "Please select a subject first!";
            }
        }
    }
}