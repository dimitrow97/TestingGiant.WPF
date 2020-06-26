using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.User;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.User
{
    public class UserConductorViewModel : BaseConductorViewModel, IHandle<AddRemoveUserGroupsMessage>
    {
        private readonly UsersAllViewModel usersAllViewModel;
        private readonly UserGroupsViewModel userGroupsViewModel;

        public UserConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            UsersAllViewModel usersAllViewModel,
            UserGroupsViewModel userGroupsViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.usersAllViewModel = usersAllViewModel;
            this.userGroupsViewModel = userGroupsViewModel;

            this.RegisterItems(this.usersAllViewModel, this.userGroupsViewModel);
        }

        public void Handle(AddRemoveUserGroupsMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.userGroupsViewModel.User = message.User;
            this.applicationRouter.ActivateItem(this.userGroupsViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            this.applicationRouter.ActivateItem(this.usersAllViewModel, this);
        }
    }
}
