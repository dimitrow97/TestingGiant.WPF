using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGiant.App.Contexts;
using TestingGiant.App.Models;
using TestingGiant.App.ViewModels.Abstraction;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App.ViewModels.EntityCruds.Exam
{
    public class ExamGroupViewModel : BaseScreenViewModel
    {
        private ExamModel exam;
        private GroupModel selectedMemberGroup;
        private GroupModel selectedNotMemberGroup;

        private BindableCollection<GroupModel> notMemberOfGroups;
        private BindableCollection<GroupModel> memberOfGroups;

        private IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository;
        private IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupsRepository;

        public ExamGroupViewModel(
            IEventAggregator eventAggregato,
            ShellContext shellContext,
            ApplicationRouter applicationRouter,
            IDeletableEntityRepository<TestingGiant.Data.Models.Exam> examsRepository,
            IDeletableEntityRepository<TestingGiant.Data.Models.Group> groupsRepository)
            : base(eventAggregato, shellContext, applicationRouter)
        {
            this.examsRepository = examsRepository;
            this.groupsRepository = groupsRepository;
        }

        public BindableCollection<GroupModel> MemberOfGroups
        {
            get
            {
                return memberOfGroups;
            }
            set
            {
                memberOfGroups = value;
                NotifyOfPropertyChange(() => MemberOfGroups);
            }
        }

        public BindableCollection<GroupModel> NotMemberOfGroups
        {
            get
            {
                return notMemberOfGroups;
            }
            set
            {
                notMemberOfGroups = value;
                NotifyOfPropertyChange(() => NotMemberOfGroups);
            }
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

                this.GetGroups();
            }
        }

        public GroupModel SelectedMemberGroup
        {
            get
            {
                return selectedMemberGroup;
            }
            set
            {
                selectedMemberGroup = value;
                NotifyOfPropertyChange(() => SelectedMemberGroup);
            }
        }

        public GroupModel SelectedNotMemberGroup
        {
            get
            {
                return selectedNotMemberGroup;
            }
            set
            {
                selectedNotMemberGroup = value;
                NotifyOfPropertyChange(() => SelectedNotMemberGroup);
            }
        }

        public void GetGroups()
        {
            this.MemberOfGroups = new BindableCollection<GroupModel>(this.examsRepository.GetById(this.Exam.Id).Groups.Select(x => new GroupModel { Id = x.Id, Name = x.GroupName }).ToList());
            this.NotMemberOfGroups = new BindableCollection<GroupModel>(this.groupsRepository.All().Where(x => !x.Exams.Any(y => y.Id == this.Exam.Id)).Select(x => new GroupModel { Id = x.Id, Name = x.GroupName }).ToList());
        }

        public void AddToGroup()
        {
            if (this.SelectedNotMemberGroup != null)
            {
                var exam = this.examsRepository.GetById(this.Exam.Id);

                exam.Groups.Add(this.groupsRepository.GetById(this.SelectedNotMemberGroup.Id));

                this.examsRepository.Update(exam);
                this.examsRepository.SaveChanges();
                this.GetGroups();
            }
            else
            {
                this.Message = "Please select a group from the \"Not a member of Groups\" table!";
            }
        }

        public void RemoveFromGroup()
        {
            if (this.SelectedMemberGroup != null)
            {
                var exam = this.examsRepository.GetById(this.Exam.Id);

                exam.Groups.Remove(this.groupsRepository.GetById(this.SelectedMemberGroup.Id));

                this.examsRepository.Update(exam);
                this.examsRepository.SaveChanges();
                this.GetGroups();
            }
            else
            {
                this.Message = "Please select a group from the \"Member of Groups\" table!";
            }
        }
    }
}
