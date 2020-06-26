namespace TestingGiant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameToExam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "Name");
        }
    }
}
