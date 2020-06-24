using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Group
{
    public class GroupEditViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private GroupModel group;
        private string name;
        private string message;
        private bool enableEditButton;

        private bool isNameOk;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupsRepository;

        public GroupEditViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupsRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.groupsRepository = groupsRepository;
        }

        public GroupModel Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                Name = value.Name;
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

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                NotifyOfPropertyChange(() => Message);
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
            if (!groupsRepository.All().Any(x => x.GroupName == this.Name && x.Id != this.Group.Id))
            {
                var group = this.groupsRepository.GetById(this.Group.Id);

                group.GroupName = this.Name;

                this.groupsRepository.Update(group);

                this.groupsRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedGroupMessage());
            }
            else
            {
                Message = "Group name is already taken!";
            }

        }
    }
}
