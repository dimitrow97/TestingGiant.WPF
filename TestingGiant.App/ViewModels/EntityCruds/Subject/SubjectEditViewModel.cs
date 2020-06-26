using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Subject
{
    public class SubjectEditViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private SubjectModel subject;
        private string name;
        private bool enableEditButton;

        private bool isNameOk;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectRepository;        

        public SubjectEditViewModel(
            IEventAggregator eventAggregator,            
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.subjectRepository = subjectRepository;
        }

        public SubjectModel Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
                Name = value.Title;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool EnableEditButton
        {
            get
            {
                return enableEditButton;
            }
            set
            {
                enableEditButton = value;
                NotifyOfPropertyChange(() => EnableEditButton);
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
                if (columnName == "Name")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Name) || Name?.Length <= 3)
                    {
                        isNameOk = false;

                        return "Name is Required";
                    }
                    else
                    {
                        isNameOk = true;
                    }
                }

                // If there's no error, null gets returned
                if (isNameOk)
                    EnableEditButton = true;

                return null;
            }
        }

        public void AttemptEdit()
        {
            if (!subjectRepository.All().Any(x => x.Title == this.Name && x.Id != this.Subject.Id))
            {
                var subject = this.subjectRepository.GetById(this.Subject.Id);

                subject.Title = this.Name;

                this.subjectRepository.Update(subject);

                this.subjectRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedSubjectMessage());
            }
            else
            {
                Message = "Subject name is already taken!";
            }

        }
    }
}
