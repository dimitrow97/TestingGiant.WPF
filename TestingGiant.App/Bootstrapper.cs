using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using System.Data.Entity;
using System.Windows;
using TestingGiant.App.Contexts;
using TestingGiant.App.ViewModels;
using TestingGiant.App.ViewModels.Authentication;
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

            builder.RegisterType<ShellContext>().SingleInstance();

            builder.RegisterType<TestingGiantDbContext>().As<DbContext>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<User>>().As<IDeletableEntityRepository<User>>().SingleInstance();
            builder.RegisterType<GenericRepository<UserCertificate>>().As<IRepository<UserCertificate>>().SingleInstance();
            builder.RegisterType<GenericRepository<UserExam>>().As<IRepository<UserExam>>().SingleInstance();
            builder.RegisterType<GenericRepository<UserGroup>>().As<IRepository<UserGroup>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Category>>().As<IDeletableEntityRepository<Category>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Certificate>>().As<IDeletableEntityRepository<Certificate>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<CertificateTemplate>>().As<IDeletableEntityRepository<CertificateTemplate>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Exam>>().As<IDeletableEntityRepository<Exam>>().SingleInstance();
            builder.RegisterType<GenericRepository<ExamCategory>>().As<IRepository<ExamCategory>>().SingleInstance();
            builder.RegisterType<GenericRepository<ExamGroup>>().As<IRepository<ExamGroup>>().SingleInstance();
            builder.RegisterType<GenericRepository<ExamQuestion>>().As<IRepository<ExamQuestion>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Group>>().As<IDeletableEntityRepository<Group>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Question>>().As<IDeletableEntityRepository<Question>>().SingleInstance();
            builder.RegisterType<GenericRepository<QuestionCategory>>().As<IRepository<QuestionCategory>>().SingleInstance();
            builder.RegisterType<GenericRepository<QuestionSubject>>().As<IRepository<QuestionSubject>>().SingleInstance();
            builder.RegisterType<GenericRepository<QuestionAnswer>>().As<IRepository<QuestionAnswer>>().SingleInstance();
            builder.RegisterType<DeletableEntityRepository<Subject>>().As<IDeletableEntityRepository<Subject>>().SingleInstance();            
        }
    }
}
