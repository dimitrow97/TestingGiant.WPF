namespace TestingGiant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoingCertificatesAndCertificateTemplates : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionSubjects", newName: "SubjectQuestions");
            DropForeignKey("dbo.Certificates", "CertificateOwnerId", "dbo.Users");
            DropForeignKey("dbo.CertificateTemplates", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Certificates", "CertificateTemplate_Id", "dbo.CertificateTemplates");
            DropForeignKey("dbo.Certificates", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Certificates", new[] { "CertificateOwnerId" });
            DropIndex("dbo.Certificates", new[] { "SubjectId" });
            DropIndex("dbo.Certificates", new[] { "CertificateTemplate_Id" });
            DropIndex("dbo.CertificateTemplates", new[] { "SubjectId" });
            DropPrimaryKey("dbo.SubjectQuestions");
            AddPrimaryKey("dbo.SubjectQuestions", new[] { "Subject_Id", "Question_Id" });
            DropTable("dbo.Certificates");
            DropTable("dbo.CertificateTemplates");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            DropPrimaryKey("dbo.SubjectQuestions");
            AddPrimaryKey("dbo.SubjectQuestions", new[] { "Question_Id", "Subject_Id" });
            CreateIndex("dbo.CertificateTemplates", "SubjectId");
            CreateIndex("dbo.Certificates", "CertificateTemplate_Id");
            CreateIndex("dbo.Certificates", "SubjectId");
            CreateIndex("dbo.Certificates", "CertificateOwnerId");
            AddForeignKey("dbo.Certificates", "SubjectId", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Certificates", "CertificateTemplate_Id", "dbo.CertificateTemplates", "Id");
            AddForeignKey("dbo.CertificateTemplates", "SubjectId", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Certificates", "CertificateOwnerId", "dbo.Users", "Id");
            RenameTable(name: "dbo.SubjectQuestions", newName: "QuestionSubjects");
        }
    }
}
