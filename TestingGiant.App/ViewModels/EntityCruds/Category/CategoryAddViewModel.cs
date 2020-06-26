using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryAddViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private string name;
        private bool enableAddButton;

        private bool isNameOk;
        
        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;        

        public CategoryAddViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.categoriesRepository = categoriesRepository;
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

        public bool EnableAddButton
        {
            get
            {
                return enableAddButton;
            }
            set
            {
                enableAddButton = value;
                NotifyOfPropertyChange(() => EnableAddButton);
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
                    EnableAddButton = true;

                return null;
            }
        }

        public void AttemptCreate()
        {
            var category = new TestingGiant.Data.Models.Category
            {
                CategoryName = this.Name
            };

            if (!categoriesRepository.All().Any(x => x.CategoryName == this.Name))
            {
                this.categoriesRepository.Add(category, shellContext.User?.Id);
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
