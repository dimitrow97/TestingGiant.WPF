using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Group
{
    public class GroupAddViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private string name;
        private bool enableAddButton;

        private bool isNameOk;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupRepository;

        public GroupAddViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.groupRepository = groupRepository;
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
            var group = new TestingGiant.Data.Models.Group
            {
                GroupName = this.Name
            };

            if (!groupRepository.All().Any(x => x.GroupName == this.Name))
            {
                this.groupRepository.Add(group, shellContext.User?.Id);
                this.groupRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedGroupMessage());
            }
            else
            {
                Message = "Group name is already taken!";
            }
        }
    }
}