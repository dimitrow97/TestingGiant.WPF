using Caliburn.Micro;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoriesAllViewModel : BaseScreenViewModel
    {
        private CategoryModel selectedCategory;
        private BindableCollection<CategoryModel> categories;
               
        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;        

        public CategoriesAllViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository)
            : base(eventAggregato, shellContext, applicationRouter)
        {            
            this.categoriesRepository = categoriesRepository;

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
                this.Message = "Please select a category first!";
            }
        }

        public void DeleteCategory()
        {
            if (this.SelectedCategory != null)
            {
                var category = this.categoriesRepository.GetById(this.SelectedCategory.Id);

                if(category != null)
                {
                    this.categoriesRepository.Delete(category);
                    this.categoriesRepository.SaveChanges();

                    this.GetCategories();

                    this.Message = string.Empty;
                }
            }
            else
            {
                this.Message = "Please select a category first!";
            }
        }
    }
}