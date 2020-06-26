namespace TestingGiant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ExamGroups", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ExamQuestions", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ExamQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.QuestionCategories", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionSubjects", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionSubjects", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.UserCertificates", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.UserCertificates", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserExams", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.UserExams", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "UserId", "dbo.Users");
            DropForeignKey("dbo.ExamGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.QuestionCategories", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.ExamCategories", "ExamId", "dbo.Exams");
            DropIndex("dbo.ExamCategories", new[] { "ExamId" });
            DropIndex("dbo.ExamCategories", new[] { "CategoryId" });
            DropIndex("dbo.ExamGroups", new[] { "ExamId" });
            DropIndex("dbo.ExamGroups", new[] { "GroupId" });
            DropIndex("dbo.UserGroups", new[] { "UserId" });
            DropIndex("dbo.UserGroups", new[] { "GroupId" });
            DropIndex("dbo.UserCertificates", new[] { "UserId" });
            DropIndex("dbo.UserCertificates", new[] { "CertificateId" });
            DropIndex("dbo.QuestionSubjects", new[] { "QuestionId" });
            DropIndex("dbo.QuestionSubjects", new[] { "SubjectId" });
            DropIndex("dbo.ExamQuestions", new[] { "ExamId" });
            DropIndex("dbo.ExamQuestions", new[] { "QuestionId" });
            DropIndex("dbo.QuestionCategories", new[] { "QuestionId" });
            DropIndex("dbo.QuestionCategories", new[] { "CategoryId" });
            DropIndex("dbo.QuestionCategories", new[] { "Exam_Id" });
            DropIndex("dbo.UserExams", new[] { "UserId" });
            DropIndex("dbo.UserExams", new[] { "ExamId" });

            DropTable("dbo.ExamCategories");
            DropTable("dbo.ExamGroups");
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserCertificates");
            DropTable("dbo.QuestionSubjects");
            DropTable("dbo.ExamQuestions");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.UserExams");

            CreateTable(
                "dbo.ExamCategories",
                c => new
                    {
                        Exam_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exam_Id, t.Category_Id })
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Exam_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.GroupExams",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Exam_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .Index(t => t.Group_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Category_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.QuestionExams",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Exam_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.QuestionSubjects",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Subject_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Question_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.UserExams",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Exam_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Exam_Id })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Exam_Id);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Group_Id })
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Group_Id);          
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserExams",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ExamId });
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Exam_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.CategoryId });
            
            CreateTable(
                "dbo.ExamQuestions",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.QuestionId });
            
            CreateTable(
                "dbo.QuestionSubjects",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.SubjectId });
            
            CreateTable(
                "dbo.UserCertificates",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CertificateId });
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId });
            
            CreateTable(
                "dbo.ExamGroups",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.GroupId });
            
            CreateTable(
                "dbo.ExamCategories",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.CategoryId });
            
            DropForeignKey("dbo.UserGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.UserExams", "User_Id", "dbo.Users");
            DropForeignKey("dbo.QuestionSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.QuestionSubjects", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.QuestionExams", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.QuestionCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.QuestionCategories", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.GroupExams", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.GroupExams", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.ExamCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.ExamCategories", "Exam_Id", "dbo.Exams");
            DropIndex("dbo.UserGroups", new[] { "Group_Id" });
            DropIndex("dbo.UserGroups", new[] { "User_Id" });
            DropIndex("dbo.UserExams", new[] { "Exam_Id" });
            DropIndex("dbo.UserExams", new[] { "User_Id" });
            DropIndex("dbo.QuestionSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.QuestionSubjects", new[] { "Question_Id" });
            DropIndex("dbo.QuestionExams", new[] { "Exam_Id" });
            DropIndex("dbo.QuestionExams", new[] { "Question_Id" });
            DropIndex("dbo.QuestionCategories", new[] { "Category_Id" });
            DropIndex("dbo.QuestionCategories", new[] { "Question_Id" });
            DropIndex("dbo.GroupExams", new[] { "Exam_Id" });
            DropIndex("dbo.GroupExams", new[] { "Group_Id" });
            DropIndex("dbo.ExamCategories", new[] { "Category_Id" });
            DropIndex("dbo.ExamCategories", new[] { "Exam_Id" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserExams");
            DropTable("dbo.QuestionSubjects");
            DropTable("dbo.QuestionExams");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.GroupExams");
            DropTable("dbo.ExamCategories");
            CreateIndex("dbo.UserExams", "ExamId");
            CreateIndex("dbo.UserExams", "UserId");
            CreateIndex("dbo.QuestionCategories", "Exam_Id");
            CreateIndex("dbo.QuestionCategories", "CategoryId");
            CreateIndex("dbo.QuestionCategories", "QuestionId");
            CreateIndex("dbo.ExamQuestions", "QuestionId");
            CreateIndex("dbo.ExamQuestions", "ExamId");
            CreateIndex("dbo.QuestionSubjects", "SubjectId");
            CreateIndex("dbo.QuestionSubjects", "QuestionId");
            CreateIndex("dbo.UserCertificates", "CertificateId");
            CreateIndex("dbo.UserCertificates", "UserId");
            CreateIndex("dbo.UserGroups", "GroupId");
            CreateIndex("dbo.UserGroups", "UserId");
            CreateIndex("dbo.ExamGroups", "GroupId");
            CreateIndex("dbo.ExamGroups", "ExamId");
            CreateIndex("dbo.ExamCategories", "CategoryId");
            CreateIndex("dbo.ExamCategories", "ExamId");
            AddForeignKey("dbo.ExamCategories", "ExamId", "dbo.Exams", "Id");
            AddForeignKey("dbo.QuestionCategories", "Exam_Id", "dbo.Exams", "Id");
            AddForeignKey("dbo.ExamGroups", "GroupId", "dbo.Groups", "Id");
            AddForeignKey("dbo.UserGroups", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserExams", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserExams", "ExamId", "dbo.Exams", "Id");
            AddForeignKey("dbo.UserCertificates", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.UserCertificates", "CertificateId", "dbo.Certificates", "Id");
            AddForeignKey("dbo.QuestionSubjects", "SubjectId", "dbo.Subjects", "Id");
            AddForeignKey("dbo.QuestionSubjects", "QuestionId", "dbo.Questions", "Id");
            AddForeignKey("dbo.QuestionCategories", "QuestionId", "dbo.Questions", "Id");
            AddForeignKey("dbo.QuestionCategories", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.ExamQuestions", "QuestionId", "dbo.Questions", "Id");
            AddForeignKey("dbo.ExamQuestions", "ExamId", "dbo.Exams", "Id");
            AddForeignKey("dbo.UserGroups", "GroupId", "dbo.Groups", "Id");
            AddForeignKey("dbo.ExamGroups", "ExamId", "dbo.Exams", "Id");
            AddForeignKey("dbo.ExamCategories", "CategoryId", "dbo.Categories", "Id");
        }
    }
}
