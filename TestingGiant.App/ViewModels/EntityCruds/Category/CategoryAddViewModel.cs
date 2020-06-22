using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages;
using TestingGiant.App.Messages.Category;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Category
{
    public class CategoryAddViewModel : Screen, IDataErrorInfo
    {
        private string name;
        private string message;
        private bool enableAddButton;

        private bool isNameOk;

        private readonly IEventAggregator eventAggregator;
        private IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository;

        private ShellContext shellContext;
        private ApplicationRouter applicationRouter;

        public CategoryAddViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Category> categoriesRepository)
        {
            this.eventAggregator = eventAggregato;
            this.shellContext = shellContext;
            this.applicationRouter = applicationRouter;
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
