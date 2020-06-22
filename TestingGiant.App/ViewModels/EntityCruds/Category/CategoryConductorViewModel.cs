using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.Messages.Category;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryConductorViewModel : Conductor<Screen>.Collection.OneActive, IHandle<AddCategoryDisplayMessage>, IHandle<SuccessfullyAddedOrEditedCategoryMessage>, IHandle<EditCategoryDisplayMessage>
    {
        private readonly IEventAggregator eventAggregator;

        private readonly CategoriesAllViewModel catergoriesAllViewModel;
        private readonly CategoryAddViewModel catergoryAddViewModel;
        private readonly CategoryEditViewModel categoryEditViewModel;

        private ShellContext shellContext;
        private ApplicationRouter applicationRouter;

        public CategoryConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            CategoriesAllViewModel catergoriesAllViewModel,
            CategoryAddViewModel catergoryAddViewModel,
            CategoryEditViewModel categoryEditViewModel)
        {
            this.eventAggregator = eventAggregator;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;

            this.catergoriesAllViewModel = catergoriesAllViewModel;
            this.catergoryAddViewModel = catergoryAddViewModel;
            this.categoryEditViewModel = categoryEditViewModel;

            Items.AddRange(new Screen[] { this.catergoriesAllViewModel, this.catergoryAddViewModel, this.categoryEditViewModel });
        }

        public void Handle(AddCategoryDisplayMessage message)
        {
            this.applicationRouter.ActivateItem(this.catergoryAddViewModel, this);
        }

        public void Handle(SuccessfullyAddedOrEditedCategoryMessage message)
        {
            this.catergoriesAllViewModel.GetCategories();
            this.applicationRouter.ActivateItem(this.catergoriesAllViewModel, this);
        }

        public void Handle(EditCategoryDisplayMessage message)
        {
            this.categoryEditViewModel.Category = message.CategoryModel;
            this.applicationRouter.ActivateItem(this.categoryEditViewModel, this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);

            this.applicationRouter.ActivateItem(this.catergoriesAllViewModel, this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}
