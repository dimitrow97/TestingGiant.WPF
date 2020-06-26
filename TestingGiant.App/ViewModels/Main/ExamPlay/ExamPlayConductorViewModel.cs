using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;

namespace TestingGiant.App.ViewModels.Main.ExamPlay
{
    public class ExamPlayConductorViewModel : BaseConductorViewModel
    {
        private ExamModel exam;

        public ExamPlayConductorViewModel(
            IEventAggregator eventAggregator,
            ShellContext shellContext,
            ApplicationRouter applicationRouter)
            : base(eventAggregator, shellContext, applicationRouter)
        {

            //this.RegisterItems();
        }

        public ExamModel Exam
        {
            get
            {
                return exam;
            }
            set
            {
                exam = value;
                NotifyOfPropertyChange(() => Exam);
            }
        }
    }
}
