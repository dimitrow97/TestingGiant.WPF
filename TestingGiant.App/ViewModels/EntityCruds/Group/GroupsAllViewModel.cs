using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Group
{
    public class GroupsAllViewModel : BaseScreenViewModel
    {
        private string message;
        private GroupModel selectedGroup;
        private BindableCollection<GroupModel> groups;
        
        private IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupRepository;        

        public GroupsAllViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.groupRepository = groupRepository;
            
            this.GetGroups();
        }

        public BindableCollection<GroupModel> Groups
        {
            get
            {
                return groups;
            }
            set
            {
                groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }

        public GroupModel SelectedGroup
        {
            get
            {
                return selectedGroup;
            }
            set
            {
                selectedGroup = value;
                NotifyOfPropertyChange(() => SelectedGroup);
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

        public void GetGroups()
        {
            this.Groups = new BindableCollection<GroupModel>(this.groupRepository.All().Select(x => new GroupModel { Id = x.Id, Name = x.GroupName }).ToList());
        }

        public void AddGroup()
        {
            this.eventAggregator.PublishOnUIThread(new AddGroupDisplayMessage());
        }

        public void EditGroup()
        {
            if (this.SelectedGroup != null)
            {
                this.eventAggregator.PublishOnUIThread(new EditGroupDisplayMessage { GroupModel = this.SelectedGroup });
            }
            else
            {
                this.Message = "Please select a group first!";
            }
        }

        public void DeleteGroup()
        {
            if (this.SelectedGroup != null)
            {
                var category = this.groupRepository.GetById(this.SelectedGroup.Id);

                if (category != null)
                {
                    this.groupRepository.Delete(category);
                    this.groupRepository.SaveChanges();

                    this.GetGroups();

                    this.Message = string.Empty;
                }
            }
            else
            {
                this.Message = "Please select a group first!";
            }
        }
    }
}