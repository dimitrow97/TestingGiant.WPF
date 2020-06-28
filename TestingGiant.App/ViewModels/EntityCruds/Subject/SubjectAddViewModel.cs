using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Subject;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Subject
{
    public class SubjectAddViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private string name;
        private bool enableAddButton;

        private bool isNameOk;
        
        private IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectRepository;        

        public SubjectAddViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Subject> subjectRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.subjectRepository = subjectRepository;
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
                    EnableAddButton = true;

                return null;
            }
        }

        public void AttemptCreate()
        {
            var subject = new TestingGiant.Data.Models.Subject
            {
                Title = this.Name
            };

            if (!subjectRepository.All().Any(x => x.Title == this.Name))
            {
                this.subjectRepository.Add(subject, shellContext.User?.Id);
                this.subjectRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedSubjectMessage());

                this.Name = string.Empty;
            }
            else
            {
                Message = "Subject title is already taken!";
            }
        }
    }
}
