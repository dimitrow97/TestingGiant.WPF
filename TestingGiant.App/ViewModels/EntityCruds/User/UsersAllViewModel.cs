using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.User;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.User
{
    public class UsersAllViewModel : BaseScreenViewModel
    {
        private UserModel selectedUser;
        private BindableCollection<UserModel> users;

        private IDeletableEntityRepository<TestingGiant.Data.Models.User> usersRepository;

        public UsersAllViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.User> usersRepository)
            : base(eventAggregato, shellContext, applicationRouter)
        {
            this.usersRepository = usersRepository;

            this.GetUsers();
        }

        public BindableCollection<UserModel> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        public UserModel SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        public void GetUsers()
        {
            this.Users = new BindableCollection<UserModel>(this.usersRepository.All()
                .Select(x => new UserModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Role = x.Role.ToString(),
                    Groups = x.Groups.Select(g => new GroupModel { Id = g.Id, Name = g.GroupName } ).ToList(),
                    Exams = x.Exams.Select(e => new ExamModel { }).ToList()
                }).ToList());
        }


        //PROMOTE/DEMOTE

        public void PromoteOrDemote()
        {
            if(this.SelectedUser != null)
            {
                var user = this.usersRepository.GetById(this.SelectedUser.Id);

                if(user.Role == UserRole.Administrator)
                {
                    user.Role = UserRole.Public;
                }
                else
                {
                    user.Role = UserRole.Administrator;
                }

                this.usersRepository.Update(user);
                this.usersRepository.SaveChanges();

                this.GetUsers();
            }
            else
            {
                this.Message = "Please select an user!";
            }
        }

        public void UserGroups()
        {
            if (this.SelectedUser != null)
            {
                this.eventAggregator.PublishOnUIThread(new AddRemoveUserGroupsMessage { User = this.SelectedUser });
            }
            else
            {
                this.Message = "Please select an user!";
            }
        }

        public void UserExams()
        {

        }
    }
}
