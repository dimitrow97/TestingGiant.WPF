using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.Exam;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Enums;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Exam
{
    public class ExamAddViewModel : BaseScreenViewModel, IDataErrorInfo
    {
        private string name;
        private bool enableAddButton;

        private bool isNameOk;

        private string examKey;
        private string examPassword;
        private decimal maximumScore;
        private decimal timeToFinishInMinutes;
        private ExamType selectedExamType;
        private SubjectModel selectedSubject;
        
        private IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository;
        private IDeletableEntityRepository<Data.Models.Subject> subjectRepository;
        private bool isExamKeyOk;
        private bool isExamPasswordOk;
        private bool isTimeToFinishInMinutesOk;
        private bool isMaximumScoreOk;

        public IReadOnlyList<ExamType> ExamTypes { get; }
        public IReadOnlyList<SubjectModel> Subjects { get; }

        public ExamAddViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository,
            IDeletableEntityRepository<Data.Models.Subject> subjectRepository)
            : base(eventAggregator, shellContext, applicationRouter)
        {
            this.examsRepository = examsRepository;
            this.subjectRepository = subjectRepository;
            
            this.ExamTypes = Enum.GetValues(typeof(ExamType)).Cast<ExamType>().ToList();
            this.Subjects = this.subjectRepository.All().Select(x => new SubjectModel { Id = x.Id, Title = x.Title }).ToList();
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

        public string ExamKey
        {
            get
            {
                return examKey;
            }
            set
            {
                examKey = value;
                NotifyOfPropertyChange(() => ExamKey);
            }
        }

        public string ExamPassword
        {
            get
            {
                return examPassword;
            }
            set
            {
                examPassword = value;
                NotifyOfPropertyChange(() => ExamPassword);
            }
        }

        public decimal MaximumScore
        {
            get
            {
                return maximumScore;
            }
            set
            {
                maximumScore = value;
                NotifyOfPropertyChange(() => MaximumScore);
            }
        }

        public decimal TimeToFinishInMinutes
        {
            get
            {
                return timeToFinishInMinutes;
            }
            set
            {
                timeToFinishInMinutes = value;
                NotifyOfPropertyChange(() => TimeToFinishInMinutes);
            }
        }

        public ExamType SelectedExamType
        {
            get => selectedExamType;
            set => Set(ref selectedExamType, value);
        }

        public SubjectModel SelectedSubject
        {
            get => selectedSubject;
            set => Set(ref selectedSubject, value);
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

                if (columnName == "ExamKey")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(ExamKey) || ExamKey?.Length <= 3)
                    {
                        isExamKeyOk = false;

                        return "Exam Key is Required";
                    }
                    else
                    {
                        isExamKeyOk = true;
                    }
                }

                if (columnName == "ExamPassword")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(ExamPassword) || ExamPassword?.Length <= 3)
                    {
                        isExamPasswordOk = false;

                        return "Exam Password is Required";
                    }
                    else
                    {
                        isExamPasswordOk = true;
                    }
                }

                if (columnName == "ExamPassword")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(ExamPassword) || ExamPassword?.Length <= 3)
                    {
                        isExamPasswordOk = false;

                        return "Exam Password is Required";
                    }
                    else
                    {
                        isExamPasswordOk = true;
                    }
                }

                if (columnName == "TimeToFinishInMinutes")
                {
                    // Validate property and return a string if there is an error
                    if (this.TimeToFinishInMinutes < 1)
                    {
                        isTimeToFinishInMinutesOk = false;

                        return "Time To Finish(min) must be greater than 1";
                    }
                    else
                    {
                        isTimeToFinishInMinutesOk = true;
                    }
                }

                if (columnName == "MaximumScore")
                {
                    // Validate property and return a string if there is an error
                    if (this.MaximumScore < 1)
                    {
                        isMaximumScoreOk = false;

                        return "Maximum Score must be greater than 1";
                    }
                    else
                    {
                        isMaximumScoreOk = true;
                    }
                }


                // If there's no error, null gets returned
                if (isNameOk && isExamKeyOk && isExamPasswordOk && isTimeToFinishInMinutesOk && isMaximumScoreOk)
                    EnableAddButton = true;

                return null;
            }
        }

        public void AttemptCreate()
        {
            var exam = new TestingGiant.Data.Models.Exam
            {
                Name = this.Name,
                ExamType = this.SelectedExamType,
                ExamKey = this.ExamKey,
                ExamPassword = this.ExamPassword,
                MaximumScore = this.MaximumScore,
                TimeToFinishInMinutes = this.TimeToFinishInMinutes,
                Subject = this.subjectRepository.GetById(SelectedSubject.Id)
            };

            if (!examsRepository.All().Any(x => x.Name == this.Name || x.ExamKey == this.ExamKey))
            {
                this.examsRepository.Add(exam, shellContext.User?.Id);
                this.examsRepository.SaveChanges();

                this.eventAggregator.PublishOnUIThread(new SuccessfullyAddedOrEditedExamMessage());
            }
            else
            {
                Message = "Exam with this key or name already exists!";
            }
        }
    }
}
