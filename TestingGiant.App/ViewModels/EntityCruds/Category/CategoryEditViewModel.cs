using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryEditViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private CategoryModel category;
        private string name;
        private bool enableEditButton;

        private bool isNameOk;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;        

        public CategoryEditViewModel(
            IEventAggregator eventAggregator,            
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public CategoryModel Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
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
            if (!categoriesRepository.All().Any(x => x.CategoryName == this.Name && x.Id != this.Category.Id))
            {
                var category = this.categoriesRepository.GetById(this.Category.Id);

                category.CategoryName = this.Name;

                this.categoriesRepository.Update(category);

                this.categoriesRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedCategoryMessage());
            }
            else
            {
                Message = "Category name is already taken!";
            }

        }
    }
}
