using Caliburn.Micro;
using System.ComponentModel;
using System.Linq;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Category;
using TestingGiant.App.Models;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryEditViewModel : Screen, IDataErrorInfo
    {
        private CategoryModel category;
        private string name;
        private string message;
        private bool enableEditButton;

        private bool isNameOk;

        private readonly IEventAggregator eventAggregator;
        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;

        private ShellContext shellContext;

        public CategoryEditViewModel(
            IEventAggregator eventAggregator,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository,
            ShellContext shellContext)
        {
            this.eventAggregator = eventAggregator;
            this.categoriesRepository = categoriesRepository;
            this.shellContext = shellContext;
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
