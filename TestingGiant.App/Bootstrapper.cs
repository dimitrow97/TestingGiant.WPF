using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using System.Data.Entity;
using System.Windows;
using TestingGiant.App.Contexts;
using TestingGiant.App.ViewModels;
using TestingGiant.App.ViewModels.Authentication;
using TestingGiant.App.ViewModels.EntityCruds.Category;
using TestingGiant.App.ViewModels.EntityCruds.Exam;
using TestingGiant.App.ViewModels.EntityCruds.Group;
using TestingGiant.App.ViewModels.EntityCruds.Question;
using TestingGiant.App.ViewModels.EntityCruds.Subject;
using TestingGiant.App.ViewModels.EntityCruds.User;
using TestingGiant.App.ViewModels.Main.Administrator;
using TestingGiant.App.ViewModels.Main.ExamPlay;
using TestingGiant.Data.DbContexts;
using TestingGiant.Data.Models;
using TestingGiant.Data.Repositories;
using TestingGiant.Data.Repositories.Interfaces;

namespace TestingGiant.App
{
    public class Bootstrapper : AutofacBootstrapper<ShellConductorViewModel>
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellConductorViewModel>();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<ShellConductorViewModel>().SingleInstance();            
            builder.RegisterType<LoginConductorViewModel>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<RegisterViewModel>().SingleInstance();
            builder.RegisterType<AdminMainConductorViewModel>().SingleInstance();
            builder.RegisterType<AdminDashboardViewModel>().SingleInstance();

            builder.RegisterType<CategoryConductorViewModel>().SingleInstance();
            builder.RegisterType<CategoriesAllViewModel>().SingleInstance();
            builder.RegisterType<CategoryAddViewModel>().SingleInstance();
            builder.RegisterType<CategoryEditViewModel>().SingleInstance();

            builder.RegisterType<GroupConductorViewModel>().SingleInstance();
            builder.RegisterType<GroupsAllViewModel>().SingleInstance();
            builder.RegisterType<GroupEditViewModel>().SingleInstance();
            builder.RegisterType<GroupAddViewModel>().SingleInstance();

            builder.RegisterType<QuestionConductorViewModel>().SingleInstance();
            builder.RegisterType<QuestionsAllViewModel>().SingleInstance();
            builder.RegisterType<QuestionAddViewModel>().SingleInstance();
            builder.RegisterType<QuestionEditViewModel>().SingleInstance();

            builder.RegisterType<SubjectConductorViewModel>().SingleInstance();
            builder.RegisterType<SubjectsAllViewModel>().SingleInstance();
            builder.RegisterType<SubjectAddViewModel>().SingleInstance();
            builder.RegisterType<SubjectEditViewModel>().SingleInstance();

            builder.RegisterType<UserConductorViewModel>().SingleInstance();
            builder.RegisterType<UsersAllViewModel>().SingleInstance();
            builder.RegisterType<UserGroupsViewModel>().SingleInstance();

            builder.RegisterType<ExamConductorViewModel>().SingleInstance();
            builder.RegisterType<ExamsAllViewModel>().SingleInstance();
            builder.RegisterType<ExamAddViewModel>().SingleInstance();
            builder.RegisterType<ExamEditViewModel>().SingleInstance();
            builder.RegisterType<ExamGroupViewModel>().SingleInstance();
            builder.RegisterType<ExamQuestionViewModel>().SingleInstance();

            builder.RegisterType<ExamPlayConductorViewModel>().SingleInstance();
            builder.RegisterType<ExamPlayLoginViewModel>().SingleInstance();
            builder.RegisterType<ExamPlayQuestionViewModel>().SingleInstance();
            builder.RegisterType<ExamPlayResultViewModel>().SingleInstance();

            builder.RegisterType<ShellContext>().SingleInstance();
            builder.RegisterType<ApplicationRouter>().SingleInstance();

            builder.RegisterType<TestingGiantDbContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<User>>().As<IDeletableEntityRepository<User>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Category>>().As<IDeletableEntityRepository<Category>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Exam>>().As<IDeletableEntityRepository<Exam>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Group>>().As<IDeletableEntityRepository<Group>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Question>>().As<IDeletableEntityRepository<Question>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<QuestionAnswer>>().As<IDeletableEntityRepository<QuestionAnswer>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Subject>>().As<IDeletableEntityRepository<Subject>>().SingleInstance();            
        }
    }
}
