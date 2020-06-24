namespace TestingGiant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamCategories",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.ExamId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamType = c.Int(nullable: false),
                        TimeToFinishInMinutes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubjectId = c.Int(nullable: false),
                        ExamKey = c.String(),
                        ExamPassword = c.String(),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.ExamGroups",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.GroupId })
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .Index(t => t.ExamId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Role = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        LastEditedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserCertificates",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CertificateId })
                .ForeignKey("dbo.Certificates", t => t.CertificateId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CertificateId);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CertificateTemplateId = c.String(),
                        CertificateOwnerId = c.Int(nullable: false),
                        OwnerScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Title = c.String(),
                        Description = c.String(),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubjectId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                        CertificateTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CertificateOwnerId)
                .ForeignKey("dbo.CertificateTemplates", t => t.CertificateTemplate_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.CertificateOwnerId)
                .Index(t => t.SubjectId)
                .Index(t => t.CertificateTemplate_Id);
            
            CreateTable(
                "dbo.CertificateTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubjectId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionSubjects",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.SubjectId })
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.QuestionId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        QuestionType = c.Int(nullable: false),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Difficulty = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Answer = c.String(),
                        IsItCorrect = c.Boolean(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        CreatorId = c.Int(nullable: false),
                        LastEditedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.QuestionId })
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .Index(t => t.ExamId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Exam_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .Index(t => t.QuestionId)
                .Index(t => t.CategoryId)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.UserExams",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ExamId })
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ExamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamCategories", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.QuestionCategories", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.ExamGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserExams", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.UserCertificates", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserCertificates", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Certificates", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Certificates", "CertificateTemplate_Id", "dbo.CertificateTemplates");
            DropForeignKey("dbo.CertificateTemplates", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.QuestionSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.QuestionSubjects", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionCategories", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ExamQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.ExamQuestions", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.QuestionAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Certificates", "CertificateOwnerId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ExamGroups", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ExamCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserExams", new[] { "ExamId" });
            DropIndex("dbo.UserExams", new[] { "UserId" });
            DropIndex("dbo.QuestionCategories", new[] { "Exam_Id" });
            DropIndex("dbo.QuestionCategories", new[] { "CategoryId" });
            DropIndex("dbo.QuestionCategories", new[] { "QuestionId" });
            DropIndex("dbo.ExamQuestions", new[] { "QuestionId" });
            DropIndex("dbo.ExamQuestions", new[] { "ExamId" });
            DropIndex("dbo.QuestionAnswers", new[] { "QuestionId" });
            DropIndex("dbo.QuestionSubjects", new[] { "SubjectId" });
            DropIndex("dbo.QuestionSubjects", new[] { "QuestionId" });
            DropIndex("dbo.CertificateTemplates", new[] { "SubjectId" });
            DropIndex("dbo.Certificates", new[] { "CertificateTemplate_Id" });
            DropIndex("dbo.Certificates", new[] { "SubjectId" });
            DropIndex("dbo.Certificates", new[] { "CertificateOwnerId" });
            DropIndex("dbo.UserCertificates", new[] { "CertificateId" });
            DropIndex("dbo.UserCertificates", new[] { "UserId" });
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.ExamGroups", new[] { "GroupId" });
            DropIndex("dbo.ExamGroups", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.ExamCategories", new[] { "CategoryId" });
            DropIndex("dbo.ExamCategories", new[] { "ExamId" });
            DropTable("dbo.UserExams");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.CertificateTemplates");
            DropTable("dbo.Certificates");
            DropTable("dbo.UserCertificates");
            DropTable("dbo.Users");
            DropTable("dbo.UserGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.ExamGroups");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamCategories");
            DropTable("dbo.Categories");
        }
    }
}
