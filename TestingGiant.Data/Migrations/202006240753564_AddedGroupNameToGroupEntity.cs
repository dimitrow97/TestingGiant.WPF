namespace TestingGiant.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroupNameToGroupEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "GroupName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "GroupName");
        }
    }
}
