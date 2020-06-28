using Caliburn.Micro;
using TestingGiant.App.Contexts;
using TestingGiant.App.Messages.ExamPlay;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.Main.ExamPlay
{
    public class ExamPlayLoginViewModel : BaseScreenViewModel
    {
        private string examKey;
        private string examPassword;

        private string examKey_UserInput;
        private string examPassword_UserInput;

        public ExamPlayLoginViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
            : base(eventAggregator, shellContext, applicationRouter)
        {
        }

        public string ExamKey { get; set; }

        public string ExamPassword { get; set; }

        public string ExamKey_UserInput
        {
            get
            {
                return examKey_UserInput;
            }
            set
            {
                examKey_UserInput = value;
                NotifyOfPropertyChange(() => ExamKey_UserInput);
            }
        }

        public string ExamPassword_UserInput
        {
            get
            {
                return examPassword_UserInput;
            }
            set
            {
                examPassword_UserInput = value;
                NotifyOfPropertyChange(() => ExamPassword_UserInput);
            }
        }

        public void GoToExam()
        {
            if(this.ExamKey_UserInput == this.ExamKey &&
                this.ExamPassword_UserInput == this.ExamPassword)
            {
                this.eventAggregator.PublishOnUIThread(new ExamPlaySuccessfulAuthMessage());
            }
            else
            {
                this.Message = "Invalid key or password";
            }
        }
    }
}