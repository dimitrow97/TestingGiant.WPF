using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Group;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.Group
{
    public class GroupConductorViewModel : BaseConductorViewModel, IHandle<AddGroupDisplayMessage>, IHandle<EditGroupDisplayMessage>, IHandle<SuccessfullyAddedOrEditedGroupMessage>
    {
        private readonly GroupsAllViewModel groupsAllViewModel;
        private readonly GroupAddViewModel groupAddViewModel;
        private readonly GroupEditViewModel groupEditViewModel;

        public GroupConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            GroupsAllViewModel groupsAllViewModel,
            GroupAddViewModel groupAddViewModel,
            GroupEditViewModel groupEditViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.groupsAllViewModel = groupsAllViewModel;
            this.groupAddViewModel = groupAddViewModel;
            this.groupEditViewModel = groupEditViewModel;

            this.RegisterItems(this.groupsAllViewModel, this.groupAddViewModel, this.groupEditViewModel);
        }

        public void Handle(SuccessfullyAddedOrEditedGroupMessage message)
        {
            this.groupsAllViewModel.GetGroups();
            this.shellContext.SaveLastMessage(message);

            this.applicationRouter.ActivateItem(this.groupsAllViewModel, this);
        }

        public void Handle(EditGroupDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.groupEditViewModel.Group = message.GroupModel;
            this.applicationRouter.ActivateItem(this.groupEditViewModel, this);
        }

        public void Handle(AddGroupDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);

            this.applicationRouter.ActivateItem(this.groupAddViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.groupsAllViewModel.GetGroups();
            this.applicationRouter.ActivateItem(this.groupsAllViewModel, this);
        }
    }
}
