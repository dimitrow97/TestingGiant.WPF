using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoriesAllViewModel : Conductor<Screen>.Collection.OneActive
    {
        private CategoryModel selectedCategory;
        private BindableCollection<CategoryModel> categories;

        private readonly IEventAggregator eventAggregator;
        private readonly CategoryAddViewModel categoryAddViewModel;
        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;

        private ShellContext shellContext;
        private ApplicationRouter applicationRouter;

        public CategoriesAllViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository,
            CategoryAddViewModel categoryAddViewModel)
        {
            this.eventAggregator = eventAggregato;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;
            this.categoriesRepository = categoriesRepository;

            this.categoryAddViewModel = categoryAddViewModel;

            Items.AddRange(new Screen[] { this.categoryAddViewModel });

            this.GetCategories();
        }

        public BindableCollection<CategoryModel> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        public CategoryModel SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
            }
        }

        public void GetCategories()
        {
            this.Categories = new BindableCollection<CategoryModel>(this.categoriesRepository.All().Select(x => new CategoryModel { Id = x.Id, Name = x.CategoryName }).ToList());
        }

        public void AddCategory()
        {
            this.eventAggregator.PublishOnUIThread(new AddCategoryDisplayMessage());
        }

        public void EditCategory()
        {
            if (this.SelectedCategory != null)
            {
                this.eventAggregator.PublishOnUIThread(new EditCategoryDisplayMessage { CategoryModel = this.SelectedCategory });
            }
            else
            {
                //message
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            this.eventAggregator.Subscribe(this);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            this.eventAggregator.Unsubscribe(this);
        }
    }
}