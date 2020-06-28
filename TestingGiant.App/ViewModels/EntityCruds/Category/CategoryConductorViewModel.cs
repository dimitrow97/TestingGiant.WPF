using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryConductorViewModel : BaseConductorViewModel, IHandle<AddCategoryDisplayMessage>, IHandle<SuccessfullyAddedOrEditedCategoryMessage>, IHandle<EditCategoryDisplayMessage>
    {
        private readonly CategoriesAllViewModel catergoriesAllViewModel;
        private readonly CategoryAddViewModel catergoryAddViewModel;
        private readonly CategoryEditViewModel categoryEditViewModel;

        public CategoryConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            CategoriesAllViewModel catergoriesAllViewModel,
            CategoryAddViewModel catergoryAddViewModel,
            CategoryEditViewModel categoryEditViewModel)
            : base(eventAggregator, shellContext, applicationRouter)
        {            
            this.catergoriesAllViewModel = catergoriesAllViewModel;
            this.catergoryAddViewModel = catergoryAddViewModel;
            this.categoryEditViewModel = categoryEditViewModel;

            this.RegisterItems(this.catergoriesAllViewModel, this.catergoryAddViewModel, this.categoryEditViewModel);
        }

        public void Handle(AddCategoryDisplayMessage message)
        {
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.catergoryAddViewModel, this);
        }

        public void Handle(SuccessfullyAddedOrEditedCategoryMessage message)
        {
            this.catergoriesAllViewModel.GetCategories();
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.catergoriesAllViewModel, this);
        }

        public void Handle(EditCategoryDisplayMessage message)
        {
            this.categoryEditViewModel.Category = message.CategoryModel;
            this.shellContext.SaveLastMessage(message);
            this.applicationRouter.ActivateItem(this.categoryEditViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.catergoriesAllViewModel.GetCategories();
            this.applicationRouter.ActivateItem(this.catergoriesAllViewModel, this);
        }
    }
}
